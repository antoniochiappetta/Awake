﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Requisiti
 * movimento direzionale ad 8
 * si stoppa e punta alla direzione attuale quando non vi e' un input
*/

public class LazBasicController : MonoBehaviour {

    public float velocity = 5;
    public float turnSpeed = 10;

    Vector2 input;
    float angle;

    Quaternion targetRotation;
    Transform camera;

    Animator animator;

    private void Start() {

        camera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    private void Update() {

        GetInput();
        CalculateRotation();
       
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

        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    /*
     * Se il player non e' grounded, la normale forward sara' uguale a transform forward
     * serve per determinare il forward vector
    */

}
