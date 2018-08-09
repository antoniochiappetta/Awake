using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Requisiti
 * Seguire a seconda della posizione X/Z del 'Terrain' del Player
 * SmoothRotating attorno al giocatore aumentando di 45 gradi
*/
public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offsetPosition;
    public float moveSpeed = 5;
    public float turnSpeed = 10;
    public float smoothSpeed = 0.5f;

    Quaternion targetRotation;
    Vector3 targetPosition;
    bool smoothRotating = false;

    void LateUpdate(){
        MoveWithTarget();
        LookAtTarget();

        //pulsanti per ruotare a destra e sinistra
        if(Input.GetKeyDown(KeyCode.G) && !smoothRotating){
            StartCoroutine("RotateAroundTarget", 45);
        }

        if (Input.GetKeyDown(KeyCode.H) && !smoothRotating) {
            StartCoroutine("RotateAroundTarget", -45);
        }



    }

    /*
     * Muove la camera con la posizione del player + offset attuale della camera
     * Offset e' modificato da RotateAroundTarget coroutine
    */
    void MoveWithTarget(){
        targetPosition = target.position + offsetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }

    /*
     * Usa il Look vector ( current e target) per mirare la camera verso il player
    */
    void LookAtTarget(){
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        
    }

    /*
     * questa coroutine puo avere solo un istanza alla volta
     * determinata da 'smoothRotating'
    */

    IEnumerator RotateAroundTarget(float angle){
        
        Vector3 velocity = Vector3.zero;
        //ruotiamo l offsetPosition per angle calcolato con Euler
        Vector3 targetOffsetPosition = Quaternion.Euler(0, angle, 0) * offsetPosition;
        float distance = Vector3.Distance(offsetPosition, targetOffsetPosition);

        smoothRotating = true;
        //e' un Lerp ottimizzato
        while(distance > 0.02f){
            offsetPosition = Vector3.SmoothDamp(offsetPosition, targetPosition, ref velocity, smoothSpeed);
            distance = Vector3.Distance(offsetPosition, targetOffsetPosition);
            yield return null;
        }

        smoothRotating = false;
        offsetPosition = targetOffsetPosition;
    }
}
