using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BadguyMovement : MonoBehaviour
{
    Rigidbody rb;
    System.Random random;

    [SerializeField] float movementSpeed = 10f;

    int movementLength = 0;
    bool isMoving = false;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        RandomMovement();
    }

    private void RandomMovement()
    {
        var speed = -movementSpeed * Time.deltaTime;
        if (movementLength == 0)
        {
            isMoving = true;
            random = new System.Random();
            int rand = random.Next(9);

            if (rand == 1)
            {
                transform.rotation = Quaternion.Euler(0f, 45, 0f);

            }
            else if (rand == 2)
            {
                transform.rotation = Quaternion.Euler(0f, -45, 0f);
            }
            else if (rand == 3)
            {
                transform.rotation = Quaternion.Euler(0f, 135, 0f);
            }
            else if (rand == 4)
            {
                transform.rotation = Quaternion.Euler(0f, -135, 0f);
            }
            else if (rand == 5)
            {
                transform.rotation = Quaternion.Euler(0f, 90, 0f);
            }
            else if (rand == 6)
            {
                transform.rotation = Quaternion.Euler(0f, 0, 0f);
            }
            else if (rand == 7)
            {
                transform.rotation = Quaternion.Euler(0f, -90, 0f);
            }
            else if (rand == 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180, 0f);
            }
            else if (rand == 9)
            {
                isMoving = false;
            }
            movementLength = random.Next(101, 201);

        }

        if (isMoving)
        {
            movementLength--;
            rb.transform.Translate(0, 0, speed);
        }
    }
}
