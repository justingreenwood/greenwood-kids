using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("WE ARE HERE!!!!!!");
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerMovement>().IsInWater(true);
        }
        else if (collider.CompareTag("Badguy"))
        {
            collider.GetComponent<BadguyMovement>().IsInWater(true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerMovement>().IsInWater(false);
        }
        else if (collider.CompareTag("Badguy"))
        {
            collider.GetComponent<BadguyMovement>().IsInWater(true);
        }
    }
}
