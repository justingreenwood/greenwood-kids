using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AntiFogAura : MonoBehaviour
{
    GuyMovement guyMovement;
    void Start()
    {
        guyMovement = GetComponent<GuyMovement>();
        
    }


    void Update()
    {
        if (tag == "Yellow Team")
        {
            Collider[] potentialFog = Physics.OverlapSphere(transform.position, guyMovement.SightRange);
            List<GameObject> fog = new List<GameObject>();
            foreach (Collider c in potentialFog)
            {
                if (c.gameObject.tag == "Fog")
                {

                    c.gameObject.SetActive(false);
                }
            }
        }
    }
}
