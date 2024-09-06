using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        var nSpeed = speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.D))
        Camera.main.transform.position += Vector3.right * nSpeed;
        if (Input.GetKey(KeyCode.A))
            Camera.main.transform.position += Vector3.left * nSpeed;
        if (Input.GetKey(KeyCode.W))
            Camera.main.transform.position += Vector3.forward * nSpeed;
        if (Input.GetKey(KeyCode.S))
            Camera.main.transform.position += Vector3.back * nSpeed;

    }
}
