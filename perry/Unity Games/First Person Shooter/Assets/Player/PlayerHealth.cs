using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100;
    DisplayDamage displayDamage;
    private void Start()
    {
        displayDamage =GetComponent<DisplayDamage>();
    }
    public void TakeDamage(float damage)
    {
        
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("You are now dead!");
        }

    }

 
}
