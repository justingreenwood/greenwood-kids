using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Sleeping: {rigidbody.IsSleeping()} Time: {Time.time:0.00}");
    }

     void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        rigidbody.WakeUp();
    }

}
