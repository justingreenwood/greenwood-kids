using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

    string team;
    ResourceBank bank;
    public int unitsAlive = 0;

    
    [SerializeField] List<GuyMovement> peasants = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> houses = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> castles = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> farmland = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> trainingFields = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> stables = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> menAtArms = new List<GuyMovement>();


    void Start()
    {
        team = gameObject.tag;
        bank = gameObject.GetComponent<ResourceBank>();

        GuyMovement[] units = FindObjectsOfType<GuyMovement>();

        foreach (GuyMovement unit in units)
        {
            if (CompareTag(unit.gameObject.tag))
            {
                if (unit.unitType == UnitType.Castle)
                {
                    castles.Add(unit);
                }
                else if (unit.unitType == UnitType.House)
                {
                    houses.Add(unit);
                }
                else if (unit.unitType == UnitType.TrainingField)
                {
                    trainingFields.Add(unit);
                }
                else if (unit.unitType == UnitType.FarmLand)
                {
                    farmland.Add(unit);
                }
                else if (unit.unitType == UnitType.Stables)
                {
                    stables.Add(unit);
                }
                else if (unit.unitType == UnitType.Builder)
                {
                    peasants.Add(unit);
                }
                else
                {
                    menAtArms.Add(unit);
                }
            }


        }

    }

    void Update()
    {

        if (castles.Count < 1)
        {
            BuildCastle();
        }
        else if(peasants.Count < bank.UnitLimit/5 || peasants.Count < 8)
        {
            if(bank.Food>= 50)
            foreach (var castle in castles)
            {
                if (!castle.IsCurrentlyBuilding && castle.isBuilt)
                {
                    GameObject chosenGO = castle.UnitGameObjects[0];
                    castle.BuildUnit(chosenGO);
                }
            }
        }
        if(peasants.Count > 4) 
        {
            foreach (var trainingField in trainingFields)
            {
                if (!trainingField.IsCurrentlyBuilding && trainingField.isBuilt)
                {
                    trainingField.BuildUnit(trainingField.UnitGameObjects[0]);
                }
            }

        }
        foreach(var peasant in peasants)
        {
            
        }


        
    }

    private void BuildCastle()
    {
        throw new NotImplementedException();
    }
}
