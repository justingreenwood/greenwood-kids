using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank : MonoBehaviour
{

    [SerializeField] int wood = 50;
    public int Wood { get { return wood; } }
    [SerializeField] int food = 50;
    public int Food { get { return food; } }
    [SerializeField] int unitLimit = 0;
    public int UnitLimit { get { return unitLimit; } }
    [SerializeField] int gems = 0;
    public int Gems { get { return gems; } }

    //public int borrowedWood = 0;
    //public int borrowedGems = 0;
    //public int borrowedFood = 0;

    int unitChangeAmount = 8;

    private void Start()
    {
        Building[] buildings = GetComponentsInChildren<Building>();
        foreach (Building building in buildings)
        {
            if (building.raisesUnitLimit)
            {
                RaiseUnitLimit();
            }
        }

    }

    public bool RemoveResource(int food, int wood, int gems)
    {
        if (wood < 0 || gems < 0 || food < 0) { return false; }
        if (wood > this.wood || gems > this.gems || food > this.food) { return false; }
        this.wood -= wood;
        this.gems -= gems;
        this.food -= food;
        return true;

    }





    public bool HasEnoughResource(int food, int wood, int gems)
    {
        if (wood < 0 || gems < 0 || food < 0) { return false; }
        if (wood > this.wood || gems > this.gems || food > this.food) { return false; }
        return true;
    }
    public void AddResource(ResourceType resourceType, int amount) 
    {

        if(resourceType == ResourceType.Wood)
        {
            wood += amount;
        }
        else if (resourceType == ResourceType.Food)
        {
            food += amount;
        }
        else if (resourceType == ResourceType.Gems)
        {
            gems += amount;
        }
    }
    public void AddResources(int food, int wood, int gems)
    {
        this.food += food;
        this.wood += wood;
        this.gems += gems;

    }
    public void RaiseUnitLimit()
    {
        unitLimit += unitChangeAmount;
    }
    public void LowerUnitLimit()
    {
        unitLimit -= unitChangeAmount;
    }
}
