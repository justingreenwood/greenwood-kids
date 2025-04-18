using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmlandActions : MonoBehaviour
{
    List<GuyMovement> farmers = new List<GuyMovement>();
    int farmerLimit = 4;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void ClearFarmers()
    {
        foreach (var farmer in farmers)
        {
            farmer.currentAction = UnitActions.Nothing;
            farmer.BuilderActions.StopAllCoroutines();
        }
    }
    public void RemoveMe(GuyMovement farmer)
    {
        farmers.Remove(farmer);
        farmer.BuilderActions.StopAllCoroutines();
    }
    public bool AddFarmer(GuyMovement farmer)
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
