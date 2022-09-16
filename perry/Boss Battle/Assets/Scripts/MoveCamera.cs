using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Player;
    public float Angle = 1F;
    public float ZoomSpeed = 0.25F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(Player.position, Vector3.down, Angle);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(Player.position, Vector3.up, Angle);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(Player.position, Vector3.right, Angle);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(Player.position, Vector3.left, Angle);
        }

        float s = Input.GetAxis("Mouse ScrollWheel");
        if (s != 0)
        {
            transform.position = transform.position * (1F + s * ZoomSpeed);
        }
        transform.LookAt(Player.position);
    }
}
