using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpModifier;
    float jumpDelay = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpDelay > 0)
        {
            jumpDelay -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpDelay <= 0)
        {
            Rigidbody2D rB = GetComponent<Rigidbody2D>();
            rB.AddForce(Vector2.up *10000 * jumpModifier * Time.deltaTime);
            jumpDelay = 1.2f;
        }
      
    }

}
