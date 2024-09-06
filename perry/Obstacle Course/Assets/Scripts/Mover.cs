using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //SerializeField makes it changeable in the object and overrides what is in the script.
    [SerializeField] float moveSpeed = 5.25f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {  
        
        MovePlayer();

    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game.");
        Debug.Log("Use arrow keys or wasd to move.");

    }

    void MovePlayer()
    {

        // Edit/Project Settings/Input Manager 
        // Input is for interaction from users.
        // GetAxis is for directional movement and string tells what key to use.
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime;
        // Time.deltaTime knows the frames per second of the computer which makes it possible to make
        // movement independent of different computers frame speed.
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime;
        xValue *= moveSpeed;
        zValue *= moveSpeed;
        transform.Translate(xValue, 0, zValue);

    }


}
