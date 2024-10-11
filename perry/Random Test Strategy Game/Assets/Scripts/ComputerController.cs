using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ComputerController : MonoBehaviour
{

    string team;
    ResourceBank bank;
    //public int unitsAlive = 0;
    public int unitsAlive = 0;

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
                    unitsAlive++;
                }
                else
                {
                    menAtArms.Add(unit);
                    unitsAlive++;
                }
            }


        }

    }

    void Update()
    {
        PeasantActions();

        if (bank.Food >= 50)
        {
            if (peasants.Count < bank.UnitLimit / 5 || peasants.Count < 16)
            {
                foreach (var castle in castles)
                {
                    if (!castle.IsCurrentlyBuilding && castle.isBuilt)
                    {
                        GameObject chosenGO = castle.UnitGameObjects[0];
                        castle.BuildUnit(chosenGO);
                        unitsAlive++;
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
            if (menAtArms.Count < 12 && bank.Food>=50)
            {
                foreach (var trainingField in trainingFields)
                {
                    if (bank.Food >= 50)
                    {
                        if (!trainingField.IsCurrentlyBuilding && trainingField.isBuilt)
                        {

                            trainingField.BuildUnit(trainingField.UnitGameObjects[0]);
                            unitsAlive++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
    }
    bool isAUnitBuildingAFarm = false;
    bool isAUnitBuildingACastle = false;
    int amountFarming = 0;
    int amountCollectingWood = 0;
    int amountbuildingStructures = 0;

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
                                Build(peasant, 4);
                            }
                        }
                        else if(farmland.Count >= 1 && amountFarming <4)
                        {
                            amountFarming++;
                            Farm(peasant);
                        }
                        else if (amountCollectingWood < 2)
                        {
                            amountCollectingWood++;
                            CollectWood(peasant);
                        }
                        else if(bank.Wood >= 100 && bank.UnitLimit <= unitsAlive+2)
                        {
                            amountbuildingStructures++;
                            Build(peasant, 1);
                        }
                        else if (bank.Wood >= 150 && trainingFields.Count <= 2&& amountbuildingStructures <=2)
                        {
                            amountbuildingStructures++;
                            Build(peasant, 2);
                        }
                        else if (bank.Wood < 5000 && amountCollectingWood < 6)
                        {
                            amountCollectingWood++;
                            CollectWood(peasant);
                        }
                    }
                }

            }
        }
    }

    private void Farm(GuyMovement peasant)
    {
        peasant.SearchForResource(ResourceType.Food);
    }

    private void CollectWood(GuyMovement peasant)
    {
        peasant.SearchForResource(ResourceType.Wood);
    }

    void Build(GuyMovement peasant, int number)
    {
        //peasant.currentAction = UnitActions.Searching;
        Vector3 buildPos = peasant.SearchForPlaceToBuild();
        if(buildPos != Vector3.zero)
        {

            peasant.basicBuilding = peasant.UnitGameObjects[number];
            peasant.BuildBuilding(buildPos);
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
        else if (unitAction.unitType == UnitType.FarmLand)
        {
            farmland.Add(unitAction);
        }
        else if (unitAction.unitType == UnitType.TrainingField)
        {
            trainingFields.Add(unitAction);
        }
        else if (unitAction.unitType == UnitType.ManAtArms)
        {
            menAtArms.Add(unitAction);
        }
        else if (unitAction.unitType == UnitType.House)
        {
            houses.Add(unitAction);
        }
        else if (unitAction.unitType == UnitType.Stables)
        {
            stables.Add(unitAction);
        }
        else if (unitAction.unitType == UnitType.Castle)
        {
            castles.Add(unitAction);
        }
    }
    
}
