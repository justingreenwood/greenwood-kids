using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusedPlayerMovement : MonoBehaviour
{
    public float distanceModifier = 0.25f;
    public float moveSpeed;
    bool isMoving;  
    Vector2 input;
    Animator animator;
    public LayerMask solidObjectsLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetBool("IsThereInput") == true)
        {
            animator.SetBool("IsThereInput", false);
        }
        if (Input.anyKey)
        {
            animator.SetBool("IsThereInput", true);
        }

        if (!isMoving)
        {
            //GetAxisRaw returns-1,0,1 depending on what direction key is pressed
            //To edit direction keys, goto Edit/Projectsettings/InputManager
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("MoveX", input.x);
            animator.SetFloat("MoveY", input.y);

            //This checks if any key input effected the movement
            //It then finds the end position of the attempted movement
            if (input != Vector2.zero)
            {
                //This is a vector3 because the transform.position is a vector3
                Vector3 targetPosition = transform.position;
                targetPosition.x += input.x*distanceModifier;
                targetPosition.y += input.y*distanceModifier;


                if (IsWalkable(targetPosition))
                {
                    StartCoroutine(Move(targetPosition));
                }
            }
        }
        animator.SetBool("IsMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;
        //mathf.epsilon is incase the number is not exactly zero
        //sqrMagnitude
        //the loop continues until the target position and the actual position are practically the same
        while ((targetPosition - transform.position).sqrMagnitude >Mathf.Epsilon) 
        {
            //does only one movement towards the target with the movement speed
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //this is why it must be in an IEnumerator and a loop
            yield return null;
        }
        //This gaurantees that the position ends at the target postion
        transform.position = targetPosition;

        isMoving = false;
    }

    bool IsWalkable(Vector3 targetPosition)
    {

        if (Physics2D.OverlapBox(targetPosition, new Vector2(0.6f, 0.6f), solidObjectsLayer))
        {
            return false;
        }
        else
        {
            return true;
        }

        //Rect currentRect = new Rect(targetPosition.x, targetPosition.y, 1.2f, 1.2f);
        //Collider2D[] hitColliders2D = Physics2D.OverlapBoxAll(targetPosition, transform.localScale, solidObjectsLayer);
        //if (hitColliders2D.Length > 0)
        //{
        //    return false;
        //}
        //return true;
    }

}
