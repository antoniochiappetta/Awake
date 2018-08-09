using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour {

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider) {
        animator.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider collider) {
        animator.SetBool("isOpen", false);
    }


}
