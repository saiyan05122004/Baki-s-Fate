using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;


public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D Player;
    public float speed;
    public float jump;

    private bool grounded;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask ground;

    public UnityEvent OnLandEvent;


    // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;


    public Animator animator;
    public float maxSpeed = 10f;
    bool jumpCheck = false;


    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Flip();
        }


        if (Input.GetButtonDown("Jump"))
        {
            jumpCheck = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        Player.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Player.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Player.velocity = new Vector2(0, 5f * jump);

        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        //animation
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        jumpCheck = false;


    }
    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

   

}
