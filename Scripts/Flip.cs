using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip: MonoBehaviour
{

    Rigidbody2D Player;
    public float speedX;
    public float speedY;
    public float horSpeed;
    public GameObject heroBody;
    bool right = true;
    bool up = true;

    // Use this for initialization
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speedX = -horSpeed;
            if (right == true)
            {
                heroBody.transform.rotation = Quaternion.Euler(0, 0, 90);
                right = false;
            }



        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speedX = horSpeed;
            if (right == false)
            {
                heroBody.transform.rotation = Quaternion.Euler(0, 0, -90);
                right = true;
            }

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speedY = horSpeed;
            if (up == true)
            {
                heroBody.transform.rotation = Quaternion.Euler(0, 0, 0);
                up = false;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speedY = -horSpeed;
            if (up == false)
            {
                heroBody.transform.rotation = Quaternion.Euler(0, 0, -180);
                up = true;
            }
        }

        transform.Translate(speedX, speedY, 0);
        speedX = 0;
        speedY = 0;

    }
}

