using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int amountOfAmmo = 10;
    [SerializeField] AmmoType type;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OOOOOOOoooooh! Ammo.");

            other.GetComponent<Ammo>().CollectAmmo(type, amountOfAmmo);

            Destroy(gameObject);
        }

    }
}
