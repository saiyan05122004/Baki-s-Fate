using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // Управление
{
    //Добавление переменных и ссылок
    public CharacterController2D controller;

    public Animator animator;
    bool jumpCheck = false;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    

    
    void Update()
    {
// Фомула для расчета скорости 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) //Условие для проверки 
        {
            jump = true;
        }

        if (Input.GetButtonDown("Jump")) // Условие для проверки и загрузки анимации
        {
            jumpCheck = true;
            animator.SetBool("IsJumping", true);
        }


    }

    void FixedUpdate()
    { 
        // Загрузка анимации и проверка переменной
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        jump = false;
    }

    public void OnLanding() // Метод для отключения анимации 
    {
        animator.SetBool("IsJumping", false);
    }
}
