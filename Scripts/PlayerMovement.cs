using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;
    bool jumpCheck = false;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpCheck = true;
            animator.SetBool("IsJumping", true);
        }


    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}