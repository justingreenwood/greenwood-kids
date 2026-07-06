using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    bool isMoving;
    bool isInWater;
    bool isRunning;
    public float moveSpeed = 1;
    public float waterSpeedMultiplier = 0.5f;
    public float runnigSpeedMultiplier = 1.5f;

    public Rigidbody2D rigidbody;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    void FixedUpdate()
    {
        animator.speed = moveSpeed;
        if (animator.GetBool("IsThereInput") == true)
        {
            animator.SetBool("IsThereInput", false);
        }
        
        if (Input.anyKey)
        {
            animator.SetBool("IsThereInput", true);
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal == 0 && vertical == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);


        
        var finalMoveSpeed = moveSpeed;
        if (isRunning)
        {
            finalMoveSpeed *= runnigSpeedMultiplier;
            animator.speed *= runnigSpeedMultiplier;
        }
        if (isInWater)
        {
            finalMoveSpeed *=waterSpeedMultiplier;
            animator.speed *= waterSpeedMultiplier;
        }
        
        rigidbody.velocity = new Vector2(horizontal, vertical)*finalMoveSpeed;

    }

    public void IsInWater(bool inWater)
    {
        isInWater = inWater;
    }

}
