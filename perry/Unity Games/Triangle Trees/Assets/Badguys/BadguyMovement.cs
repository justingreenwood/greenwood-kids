using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadguyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    bool chasingPlayer = false;
    bool isInWater = false;
    bool isMoving = false;
    public float moveSpeed = 2;
    public float waterSpeedMultiplier = 0.5f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        if (!chasingPlayer && !isMoving)
        {
            MoveRandomly();
        }      
    }

    void MoveRandomly()
    {
        int randomDirection = Random.Range(0, 8);
        Vector2 direction = Vector2.zero;


        int distance = Random.Range(1, 4);
        distance *= 1000;
        float finalMoveSpeed = moveSpeed;
        if (isInWater)
        {
            finalMoveSpeed *= waterSpeedMultiplier;
        }
        if (randomDirection == 0)
        {
            direction = Vector2.zero;
        }
        else if (randomDirection == 1)
        {
            direction = new Vector2(0, 1);
        }
        else if (randomDirection == 2)
        {
            direction = new Vector2(1, 1);
        }
        else if (randomDirection == 3)
        {
            direction = new Vector2(1, 0);
        }
        else if (randomDirection == 4)
        {
            direction = new Vector2(1, -1);
        }
        else if (randomDirection == 5)
        {
            direction = new Vector2(0, -1);
        }
        else if (randomDirection == 6)
        {
            direction = new Vector2(-1, -1);
        }
        else if (randomDirection == 7)
        {
            direction = new Vector2(-1, 0);
        }
        else if (randomDirection == 8)
        {
            direction = new Vector2(-1, 1);
        }
        StartCoroutine(Move(direction, finalMoveSpeed, distance));


    }

    IEnumerator Move(Vector2 direction, float speed, int distance)
    {
        if(direction != Vector2.zero) 
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
        }
        isMoving = true;        
        for (int i = 0; i < distance; i++)
        {
            
            rb.velocity = direction * speed;

            yield return 10000;
        }
        isMoving = false;
        animator.SetBool("IsMoving", false);
        isMoving = false;
    }

    public void IsInWater(bool inWater)
    {
        isInWater = inWater;
    }


}
