using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;

    public bool isGrounded;

    void Awake() 
    {
        controller = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        controller.anim.SetBool("IsJumping", false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = true;
        controller.anim.SetBool("IsJumping", false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}
