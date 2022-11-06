using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class CharacterControllerScript : MonoBehaviour
{
    
    public float maxSpeed = 10f;
    public int jump_study = 0;

    private bool isFacingRight = true;
    
    public Animator anim;
    public float jump;
    bool grounded = true;
    public UnityEvent OnLandEvent;
    public int extraJumpsValue;
    public float jumpForce;
    private bool isGround;
    private int ExtraJump;
    private Rigidbody2D rb;

    private bool m_Grounded;







    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    private void FixedUpdate()
    {
       
        float move = Input.GetAxis("Horizontal");
        
       
        anim.SetFloat("Speed", Mathf.Abs(move));

        
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        
        if (move > 0 && !isFacingRight)
            
            Flip();
       
        else if (move < 0 && isFacingRight)
            Flip();


      
    }

 

   public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    
    private void Flip()
    {
        
        isFacingRight = !isFacingRight;
        
        Vector3 theScale = transform.localScale;
        
        theScale.x *= -1;
        
        transform.localScale = theScale;
    }

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                anim.SetBool("IsJumping", true);
            }
        }
          
       

        {
            if (isGround == true)
            {
                ExtraJump = extraJumpsValue;
            }


            if (Input.GetKeyDown(KeyCode.Space) && ExtraJump > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                ExtraJump--;
                jump_study++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && ExtraJump == 0 && isGround == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }




    }
   

}