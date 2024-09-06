using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
{
    [SerializeField] float intensity = 50;
    [SerializeField] float angle = 50;


    Torch torch;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            torch = other.gameObject.GetComponentInChildren<Torch>();
            torch.Restore(intensity, angle);
            Destroy(gameObject);

        }
    }

    
    void Update()
    {
        
    }
}
