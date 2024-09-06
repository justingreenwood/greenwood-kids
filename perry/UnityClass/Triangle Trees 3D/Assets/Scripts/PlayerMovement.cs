using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float runningMultiplier = 1.5f;
    Rigidbody rb;

    bool isAlive = true;

    const float leftDirection = 90;
    const float rightDirection =-90;
    const float upDirection = 180;
    const float downDirection = 0;
    const float downLeftDirection = 45;
    const float downRightDirection = -45;
    const float upLeftDirection = 135;
    const float upRightDirection = -135;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        if (isAlive)
        {
            RotateAndMove();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Badguy")
        {
            isAlive = false;
        }

    }

    void RotateAndMove()
    {
        var speed = -movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= runningMultiplier;
        }


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, upLeftDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, downLeftDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, upRightDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, downRightDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, upDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, downDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, leftDirection, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, rightDirection, 0f);
        }
        else 
        {
            return;
        }
        rb.transform.Translate(0, 0, speed);
    }
}
