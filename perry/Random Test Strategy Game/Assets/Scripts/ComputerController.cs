using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ComputerController : MonoBehaviour
{
    [SerializeField] Vector3 targetCoordinate;
    string team;
    ResourceBank bank;
    public int unitsAlive = 0;
    bool isAttacking = false;
    public UnitLibrary unitLibrary;

    bool canSpendWood = true;


    void Start()
    {
        team = gameObject.tag;
        bank = gameObject.GetComponent<ResourceBank>();

        GuyMovement[] units = FindObjectsOfType<GuyMovement>();

        unitLibrary = GetComponent<UnitLibrary>();

    }

    void Update()
    {
        int farmersNeeded = 0;
        int treeChoppersNeeded = 0;
        int minersNeeded = 0;
        int amountFarming = 0;
        int amountCollectingWood = 0;
        foreach (var peasant in unitLibrary.peasants)
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

        if (unitLibrary.castles.Count > 0)
        {
            if (unitLibrary.farmland.Count > 0)
            {
                if (unitLibrary.trainingFields.Count > 2)
                {
                    treeChoppersNeeded = Mathf.RoundToInt(unitLibrary.peasants.Count / 3);
                    farmersNeeded = Mathf.RoundToInt(unitLibrary.peasants.Count / 2);
                    EnsureExtraPeasants(farmersNeeded, treeChoppersNeeded);
                }
                else
                {
                    treeChoppersNeeded = Mathf.RoundToInt((unitLibrary.peasants.Count / 2));
                    farmersNeeded = Mathf.RoundToInt(unitLibrary.peasants.Count / 3);
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
            if (unitLibrary.peasants.Count < bank.UnitLimit / 5 || unitLibrary.peasants.Count < 16)
            {
                foreach (var castle in unitLibrary.castles)
                {
                    if (!castle.IsCurrentlyBuilding && castle.BuildingActions.isBuilt)
                    {
                        GameObject chosenGO = castle.UnitGameObjects[0];
                        castle.BuildingActions.BuildUnit(chosenGO);
                        unitsAlive++;
                    }
                }
            }
        }
        TrainingFieldActions();
        
        if(unitLibrary.menAtArms.Count >= 8 && isAttacking == false)
        {
            Attack();
        }
        else if(isAttacking == true && unitLibrary.menAtArms.Count >= 10)
        {
            isAttacking = false;
        }
        if(unitLibrary.archers.Count > 0 && unitLibrary.castles.Count > 0)
        {
            foreach (var castle in unitLibrary.castles)
            {
                Tower tower = castle.GetComponent<Tower>();
                if (tower.housedUnits.Count < 8)
                {
                    var neededUnits = 8 - tower.housedUnits.Count;

                    foreach (var archer in unitLibrary.archers)
                    {
                        if (archer.gameObject.activeInHierarchy)
                        {
                            if(neededUnits > 0)
                            {
                                archer.EnterTower(tower);
                                neededUnits--;
                            }
                        }
                    }
                }

            }
            
        }
    }

    private void EnsureExtraPeasants(int farmersNeeded, int treeChoppersNeeded)
    {
        if (unitLibrary.peasants.Count > farmersNeeded + treeChoppersNeeded)
        {
            treeChoppersNeeded--;
        }
        if (unitLibrary.peasants.Count > 7)
        {
            treeChoppersNeeded--;
        }
        if (unitLibrary.peasants.Count > 9)
        {
            treeChoppersNeeded--;
            farmersNeeded--;
        }
    }

    private void TrainingFieldActions()
    {
        if (unitLibrary.trainingFields.Count > 0)
        {
            if (unitLibrary.menAtArms.Count < 12)
            {
                foreach (var trainingField in unitLibrary.trainingFields)
                {
                    if (trainingField.BuildingActions.isBuilt == true)
                    {
                        if (bank.Food >= 50 && bank.UnitLimit > unitsAlive)
                        {
                            if (!trainingField.IsCurrentlyBuilding && trainingField.BuildingActions.isBuilt)
                            {
                                trainingField.BuildingActions.BuildUnit(trainingField.UnitGameObjects[0]);
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
        if (unitLibrary.peasants.Count >= 1)
        {
            
           
            for (int i = 0; i < unitLibrary.peasants.Count; i++)
            {
               
                GuyMovement peasant = unitLibrary.peasants[i];
                if (peasant.currentAction != UnitActions.Build)
                {
                    
                    if (peasant.currentAction == UnitActions.Attack)
                    {

                    }
                    else if (peasant.currentAction == UnitActions.Nothing)
                    {
                        if (unitLibrary.castles.Count == 0)
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
                        else if (unitLibrary.farmland.Count == 0)
                        {
                            if (bank.Wood < 50)
                            {
                                canSpendWood = false;
                                CollectWood(peasant);
                            }
                            else
                            {
                                Debug.Log("HEY OVER HERE");
                                canSpendWood = true;
                                Build(peasant, 4);
                            }
                        }
                        else if(unitLibrary.farmland.Count >= 1 && farming < farmersNeeded)
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
                        else if (bank.Wood >= 150 && unitLibrary.trainingFields.Count < 4)
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

    private void Attack()
    {
        isAttacking = true;
        int i = 0;
        foreach (var unit in unitLibrary.menAtArms) 
        {
            i++;
            unit.Move(targetCoordinate);
        }
    }
}
