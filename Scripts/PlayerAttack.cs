using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
            
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
