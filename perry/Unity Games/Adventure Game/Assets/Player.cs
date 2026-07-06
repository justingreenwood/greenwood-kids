using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
            transform.Translate((Input.mousePosition-transform.position)*Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            if(transform.position.y<5-.4)
            transform.Translate(0, speed * Time.deltaTime, 0);        
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -5 + .4)
                transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -8 + .4)
                transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 8 - .4)
                transform.Translate(speed * Time.deltaTime, 0, 0);
        }

    }
}
