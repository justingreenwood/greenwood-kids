using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float northernLimit = 500f;
    [SerializeField] float southernLimit = 0f;
    [SerializeField] float easternLimit = 500f;
    [SerializeField] float westernLimit = 0f;


    void Update()
    {


        float speed = movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) && transform.position.z <= northernLimit)
        {
            Camera.main.transform.position+=Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= westernLimit)
        {
            Camera.main.transform.position += Vector3.left * speed;
        }
        if(Input.GetKey(KeyCode.S) && transform.position.z >= southernLimit)
        {
            Camera.main.transform.position += Vector3.back * speed;
        }
        if(Input.GetKey(KeyCode.D) && transform.position.x <= easternLimit)
        {
            Camera.main.transform.position += Vector3.right * speed;
        }

    }
}
