using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] float movementSpeed = 10f;

    void Update()
    {


        float speed = movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            Camera.main.transform.position+=Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Camera.main.transform.position += Vector3.left * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            Camera.main.transform.position += Vector3.back * speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            Camera.main.transform.position += Vector3.right * speed;
        }

    }
}
