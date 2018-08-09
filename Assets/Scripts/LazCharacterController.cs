using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Requisiti
 * movimento direzionale ad 8
 * si stoppa e punta alla direzione attuale quando non vi e' un input
*/

public class LazCharacterController : MonoBehaviour {

    public float velocity = 5;
    public float turnSpeed = 10;
    public float height = 0.5f;
    public float heightPadding = 0.05f;
    public LayerMask ground;
    public float maxGroundAngle = 120;
    public bool debug;

    Vector2 input;
    float angle;
    float groundAngle;

    Quaternion targetRotation;
    Transform camera;

    Vector3 forward;
    RaycastHit hitInfo;
    bool grounded;

    Animator animator;

    private void Start() {

        camera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    private void Update() {

        GetInput();
        CalculateRotation();
        CalculateForward();
        CalculateGroundAngle();
        CheckGround();
        AppleyGravity();
        DrawDebugLines();

        //controllo se effettivamente ci sono degli input
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;


        Rotate();
        Move();
    }

    ///Input basati sulle keys Horizonal e Vertical
    void GetInput() {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("BlendX", input.x);
        animator.SetFloat("BlendY", input.y);

    }

    /// Direzione relatiba alla rotazione della camera
    void CalculateRotation() {
        
        //angolo e' uguale alla tangente
        angle = Mathf.Atan2(input.x, input.y);
        //converto in gradi da radianti
        angle = Mathf.Rad2Deg * angle;
        //ci assicuriamop che ci muoviamo e rotiamo attorno
        //in pratica aggiungiamo l'angolo ogni volta che si gira
        angle += camera.eulerAngles.y;


        
    }

    /// Ruota verso l'angolo calcolato 
    void Rotate(){
        //calcoliamo la rotazione, prendiamo un angolo Euler e lo convertiamo in Quaternion per targetRotation
        targetRotation = Quaternion.Euler(0, angle, 0);
        //Slerp crea una interpolazione Smooth per la rotazione
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }

    /// Il Player si muove solo lungo l'asse "in avanti"
    /// per fare avanti e indietro con il rigidbody e' chiu complicat!
    void Move(){

        if (groundAngle >= maxGroundAngle) return;
        transform.position += forward * velocity * Time.deltaTime;
    }

    /*
     * Se il player non e' grounded, la normale forward sara' uguale a transform forward
     * serve per determinare il forward vector
    */
    void CalculateForward() {
        if(!grounded){
            forward = transform.forward;
            return;
        }

        forward = Vector3.Cross(transform.right ,hitInfo.normal);
    }

    /*
     * usa un angolo Vector3 tra ground ed il transform forward per capire che altezza ha il suolo
    */
    void CalculateGroundAngle(){
        if (!grounded) {
            groundAngle = 90;
            return;
        }

        groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
    }

    /*
     * Utilizza un raycast di lunghezza height per determinare se Player ha toccato il suolo
    */
    void CheckGround(){
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, height + heightPadding, ground)){

            if (Vector3.Distance(transform.position, hitInfo.point) < height){
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * height, 5 * Time.deltaTime);
            }

            grounded = true;
        } else {
            grounded = false;
        }
    }

    /*
     * Se Player non e' grounded dovrebbe cadere
    */
    void AppleyGravity(){

        if (!grounded) {
            transform.position += Physics.gravity * Time.deltaTime;
        }

    }

    /*
     * disegna delle linee debug per controllare il grounded
     * l altezza ed il padding di altezza tra player ed il suolo
    */
    void DrawDebugLines(){

        if (!debug) return;

        Debug.DrawLine(transform.position, transform.position + forward * height * 2, Color.blue);
        Debug.DrawLine(transform.position, transform.position - Vector3.up * height, Color.green);
    }
}
