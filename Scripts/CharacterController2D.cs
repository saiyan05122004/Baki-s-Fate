using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;


public class CharacterController2D : MonoBehaviour // Механика управления
{
    //Добавление переменных и ссылок
    private Rigidbody2D Player;
    public float speed;
    public float jump;

    private bool grounded;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask ground;

    public UnityEvent OnLandEvent;


    
    private Vector3 m_Velocity = Vector3.zero;


    public Animator animator;
    public float maxSpeed = 10f;
    bool jumpCheck = false;


    void Start() 
    {
        Player = GetComponent<Rigidbody2D>(); //Получаем доступ к компоненту Rigidbody2D Игрока
    }
    void Update() 
        //Код с условием, для поворота игрока в сторону куда он движется (ссылка private void Flip)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Flip();
        }

         //Проверка нахождения игрока на земле и загрузка анимации
        if (Input.GetButtonDown("Jump"))
        {
            jumpCheck = true;
            animator.SetBool("IsJumping", false);
        }
        
    }

    void FixedUpdate() 
    {
        // Код для прыжка Игрока и проверки (находится ли он на земле).
        Player.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Player.velocity.x , z);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) // Условие с вводом данных
        {
            Player.velocity = new Vector2(0, 5f * jump);

        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground); 
        
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        jumpCheck = false;


    }
    // Проверка в какую сторону смотрит игрок
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
