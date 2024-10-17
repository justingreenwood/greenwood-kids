using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ComputerController : MonoBehaviour
{
    [SerializeField] Vector3 targetCoordinate;
    string team;
    ResourceBank bank;
    //public int unitsAlive = 0;
    public int unitsAlive = 0;
    bool isAttacking = false;
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
        int farmersNeeded = 0;
        int treeChoppersNeeded = 0;
        int minersNeeded = 0;
        int amountFarming = 0;
        int amountCollectingWood = 0;
        foreach (var peasant in peasants)
        {
            if (peasant.currentAction == UnitActions.ChopTree)
            {
                amountCollectingWood++;
            }
            else if (peasant.currentAction == UnitActions.Farm)
            {
                amountFarming++;
            }
        }

        if(castles.Count > 0)
        {
            if (farmland.Count > 0)
            {
                if (trainingFields.Count > 2)
                {
                    treeChoppersNeeded = Mathf.RoundToInt((peasants.Count / 3));
                    farmersNeeded = Mathf.RoundToInt(peasants.Count / 2);
                    EnsureExtraPeasants(farmersNeeded, treeChoppersNeeded);
                }
                else
                {
                    treeChoppersNeeded = Mathf.RoundToInt((peasants.Count / 2));
                    farmersNeeded = Mathf.RoundToInt(peasants.Count / 3);
                    EnsureExtraPeasants(farmersNeeded, treeChoppersNeeded);
                }
            }
            else
            {

            }


        }

        PeasantActions(farmersNeeded, treeChoppersNeeded, minersNeeded, amountFarming, amountCollectingWood);

        if (bank.Food >= 50 && bank.UnitLimit > unitsAlive)
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
        
        if(menAtArms.Count >= 8 && isAttacking == false)
        {
            Attack();
        }
        else if(isAttacking == true && menAtArms.Count >= 10)
        {
            isAttacking = false;
        }

    }

    private void EnsureExtraPeasants(int farmersNeeded, int treeChoppersNeeded)
    {
        if (peasants.Count > farmersNeeded + treeChoppersNeeded)
        {
            treeChoppersNeeded--;
        }
        if (peasants.Count > 7)
        {
            treeChoppersNeeded--;
        }
        if (peasants.Count > 9)
        {
            treeChoppersNeeded--;
            farmersNeeded--;
        }
    }

    private void TrainingFieldActions()
    {
        if (trainingFields.Count > 0)
        {
            if (menAtArms.Count < 12)
            {
                foreach (var trainingField in trainingFields)
                {
                    if (trainingField.isBuilt == true)
                    {
                        if (bank.Food >= 50 && bank.UnitLimit > unitsAlive)
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
                    else
                    {
                        break;
                    }
                }

            }
        }
    }

   

    private void PeasantActions(int farmersNeeded, int treeChoppersNeeded, int minersNeeded, int farming, int collectingWood)
    {
        if (peasants.Count >= 1)
        {
            
           
            for (int i = 0; i < peasants.Count; i++)
            {
                GuyMovement peasant = peasants[i];
                if (peasant.currentAction != UnitActions.Build)
                {
                    if (peasant.currentAction == UnitActions.Attack)
                    {

                    }
                    else if (peasant.currentAction == UnitActions.Nothing)
                    {
                        if (castles.Count == 0)
                        {
                            if (bank.Wood < 50)
                            {
                                canSpendWood = false;
                                CollectWood(peasant);
                            }
                            else
                            {
                                canSpendWood = true;
                                Build(peasant, 1);
                            }
                        }
                        else if (farmland.Count == 0)
                        {
                            if (bank.Wood < 50)
                            {
                                canSpendWood = false;
                                CollectWood(peasant);
                            }
                            else
                            {
                                canSpendWood = true;
                                Build(peasant, 4);
                            }
                        }
                        else if(farmland.Count >= 1 && farming < farmersNeeded)
                        {
                            farming++;
                            Farm(peasant);
                        }
                        else if (collectingWood < treeChoppersNeeded)
                        {
                            collectingWood++;
                            CollectWood(peasant);
                        }
                        else if(bank.Wood >= 100 && bank.UnitLimit <= unitsAlive+2)
                        {
                            Build(peasant, 1);
                        }
                        else if (bank.Wood >= 150 && trainingFields.Count < 4)
                        {
                            Build(peasant, 2);
                        }
                        else
                        {
                            Farm(peasant);
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
        peasant.basicBuilding = peasant.UnitGameObjects[number];
        Vector3 buildPos = peasant.SearchForPlaceToBuild();
        if(buildPos != Vector3.zero)
        {

            peasant.BuildBuilding(buildPos);
        }
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
    
    private void Attack()
    {
        isAttacking = true;
        int i = 0;
        foreach (var unit in menAtArms) 
        {
            i++;
            unit.Move(targetCoordinate);
        }
    }
}
