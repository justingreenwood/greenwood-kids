using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmlandActions : MonoBehaviour
{
    [SerializeField] List<BuilderActions> farmers = new List<BuilderActions>();
    int farmerLimit = 4;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public bool HasMaxFarmers()
    {

        if(farmers.Count == farmerLimit)
        {
            Debug.Log("I already have max farmers.");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearFarmers()
    {
        foreach (var farmer in farmers)
        {            
            farmer.StopFarming();
        }
    }
    public void RemoveMe(BuilderActions farmer)
    {
        farmers.Remove(farmer);       
    }
    public bool AddFarmer(BuilderActions farmer)
    {
        if (farmers.Count < farmerLimit)
        {
            farmers.Add(farmer);
            return true;
        }
        else
        {
            return false;
        }
    }

}
