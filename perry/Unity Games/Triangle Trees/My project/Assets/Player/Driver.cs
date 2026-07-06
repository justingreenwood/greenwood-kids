using UnityEngine;
using UnityEngine.InputSystem;


public class Driver : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.2f;
    [SerializeField] float moveSpeed = 0.01f;

    void Update()
    {
        float move = 0;
        float rotation = 0;


        if (Keyboard.current.wKey.isPressed)
        {
            move = 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1;
        }
        if(move == 1)
        {
            if (Keyboard.current.aKey.isPressed)
            {
                rotation = 1;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                rotation = -1;
            }
        }
        if (move == -1)
        {
            if (Keyboard.current.aKey.isPressed)
            {
                rotation = -1;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                rotation = 1;
            }
        }
        float finalMovement = move * moveSpeed * Time.deltaTime;
        float finalRotation = rotation * rotationSpeed * Time.deltaTime;

        transform.Translate(0, finalMovement, 0);
        transform.Rotate(0, 0, finalRotation);


    }
}
