using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] int resources = 100;
    public int Resources {  get { return resources; } }
    [SerializeField] ResourceType resourceType;
    public ResourceType Type { get {  return resourceType; } }

 
    private void Update()
    {
        if (resources <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int CollectResource(int amount)
    {
        if(resources>=amount)
        {
            resources -= amount;
            return amount;
        }
        else 
        {
            int newAmount = resources;
            resources = 0;
            return newAmount;
            
        }

    }

}
