using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHelth = 100;
    int currentHelth;
    // Start is called before the first frame update
    void Start()
    {
        currentHelth = maxHelth;
    }

    public void TakeDamage(int damge)
    {
        currentHelth -= damge;

        if (currentHelth <= 0)
        {
            Die();
        }
    }

    void Die()
    
    {
        Debug.Log("Enemy died!");
        Destroy(this.gameObject);
    }
}
