using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

    string team;
    ResourceBank bank;
    //public int unitsAlive = 0;

    
    [SerializeField] List<GuyMovement> peasants = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> houses = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> castles = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> farmland = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> trainingFields = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> stables = new List<GuyMovement>();
    [SerializeField] List<GuyMovement> menAtArms = new List<GuyMovement>();

    bool canSpendWood = true;


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
        PeasantActions();

        if (bank.Food >= 50)
        {
            if (peasants.Count < bank.UnitLimit / 5 || peasants.Count < 8)
            {
                foreach (var castle in castles)
                {
                    if (!castle.IsCurrentlyBuilding && castle.isBuilt)
                    {
                        GameObject chosenGO = castle.UnitGameObjects[0];
                        castle.BuildUnit(chosenGO);
                    }
                }
            }
        }
        
        TrainingFieldActions();
        

    }

    private void TrainingFieldActions()
    {
        if (trainingFields.Count > 0)
        {
            if (peasants.Count > 4)
            {
                foreach (var trainingField in trainingFields)
                {
                    if (!trainingField.IsCurrentlyBuilding && trainingField.isBuilt)
                    {
                        trainingField.BuildUnit(trainingField.UnitGameObjects[0]);
                    }
                }

            }
        }
    }
    bool isAUnitBuildingAFarm = false;
    bool isAUnitBuildingACastle = false;
    private void PeasantActions()
    {
        if (peasants.Count >= 1)
        {
            
           
            for (int i = 0; i < peasants.Count; i++)
            {
                GuyMovement peasant = peasants[i];
                //if (peasant.currentAction != UnitActions.Build)
                if (peasant.currentAction == UnitActions.Nothing)
                {
                    if (peasant.currentAction == UnitActions.Attack)
                    {

                    }
                    else if (peasant.currentAction == UnitActions.Nothing)
                    {
                        if (castles.Count == 0 && !isAUnitBuildingACastle)
                        {
                            if (bank.Wood < 50)
                            {
                                canSpendWood = false;
                                CollectWood(peasant);
                            }
                            else
                            {
                                canSpendWood = true;
                                BuildCastle(peasant);
                            }
                        }
                        else if (farmland.Count == 0 && !isAUnitBuildingAFarm)
                        {
                            if (bank.Wood < 50)
                            {
                                canSpendWood = false;
                                CollectWood(peasant);
                            }
                            else
                            {
                                canSpendWood = true;
                                isAUnitBuildingAFarm = true;
                                //peasant.currentAction = UnitActions.Build;
                                BuildFarm(peasant);
                            }
                        }
                        else if(farmland.Count >= 1)
                        {
                            Farm(peasant);
                        }
                        else if (bank.Wood < 2000)
                        {
                            CollectWood(peasant);
                        }
                    }
                }

            }
        }
    }

    private void Farm(GuyMovement peasant)
    {
    }

    private void CollectWood(GuyMovement peasant)
    {
        peasant.SearchForResource(ResourceType.Wood);
    }

    void BuildFarm(GuyMovement peasant)
    {
        //peasant.currentAction = UnitActions.Searching;
        Vector3 buildPos = peasant.SearchForPlaceToBuild();
        if(buildPos != Vector3.zero)
        {

            peasant.basicBuilding = peasant.UnitGameObjects[4];
            bool butt = peasant.BuildBuilding(buildPos);
            Debug.Log(butt);
        }
    }

    private void BuildCastle(GuyMovement peasant)
    {
        
    }

    public void AddUnit(GuyMovement unitAction)
    {
        if (unitAction.unitType == UnitType.Builder)
        {
            peasants.Add(unitAction);
        }
    }
    
}
