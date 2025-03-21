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

    [SerializeField] int amountToAttack = 8;
    [SerializeField] bool attackAtStart = false;

    string team;
    ResourceBank bank;
    public int unitsAlive = 0;
    bool isAttacking = false;
    public UnitLibrary uLib;
    public Information techInfo;

    bool canSpendWood = true;

    int farmersNeeded = 0;
    int amountFarming = 0;
    int treeChoppersNeeded = 0;
    int amountCollectingWood = 0;
    int minersNeeded = 0;
    int amountMining = 0;
    int amountWorking = 0;
    

    bool needCollectors = true;
    void Start()
    {
        team = gameObject.tag;
        bank = gameObject.GetComponent<ResourceBank>();
        techInfo = gameObject.GetComponent<Information>();

        GuyMovement[] units = FindObjectsOfType<GuyMovement>();

        uLib = GetComponent<UnitLibrary>();
        
        foreach(GuyMovement peasant in uLib.peasants)
        {

            peasant.currentAction = UnitActions.ChopTree;
            amountCollectingWood++;
        }
        if (attackAtStart)
        {
            ShouldWeAttack();
        }
    }
    public bool needToCheck = true;
    void Update()
    {
        
        if (needToCheck)
        {
            Debug.Log("Check Time");
            if (uLib.peasants.Count >= 3)
            {

                if (uLib.farmland.Count < 1)
                {
                    if (bank.Wood < 50)
                    {
                        Build(uLib.peasants[0], UnitType.FarmLand);

                    }
                }
                else if (amountFarming < 2)
                {
                    ResourceCollectorDelegator(amountFarming, ResourceType.Food);
                }
                if (amountCollectingWood < 2)
                {
                    ResourceCollectorDelegator(amountCollectingWood, ResourceType.Wood);
                }

            }
            else if (uLib.peasants.Count == 2)
            {
                if (uLib.farmland.Count >= 1)
                {
                    uLib.peasants[0].BuilderActions.SearchForResource(ResourceType.Food);
                    uLib.peasants[1].BuilderActions.SearchForResource(ResourceType.Wood);
                }
                else
                {
                    uLib.peasants[0].BuilderActions.SearchForResource(ResourceType.Wood);
                    uLib.peasants[1].BuilderActions.SearchForResource(ResourceType.Wood);
                }
            }
            else if (uLib.peasants.Count == 1)
            {
                if (uLib.farmland.Count >= 1)
                {
                    uLib.peasants[0].BuilderActions.SearchForResource(ResourceType.Wood);
                }
                else
                {
                    uLib.peasants[0].BuilderActions.SearchForResource(ResourceType.Food);
                }
            }
            needToCheck = false;
        }
        if (uLib.peasants.Count >= 2)
        {
            if (uLib.farmland.Count < 1)
            {
                if (bank.Wood >= 50)
                {
                    Build(uLib.peasants[0], UnitType.FarmLand);
                }
            }
            else
            {
                needToCheck = true;
                if (uLib.castles.Count < 1)
                {
                    if (bank.Wood >= 1000)
                    {
                        Build(uLib.peasants[0], UnitType.TrainingField);
                    }
                }
                else
                {
                    CastleActions();

                    if (uLib.trainingFields.Count < 1)
                    {
                        if (bank.Wood >= 150)
                        {
                            Build(uLib.peasants[0], UnitType.TrainingField);
                        }
                    }
                    else
                    {
                        TrainingFieldActions();

                        if (uLib.blackSmiths.Count < 1)
                        {
                            if (bank.Wood >= 250 && bank.Gems >= 50)
                            {
                                Build(uLib.peasants[0], UnitType.BlackSmith);
                            }
                        }
                        else
                        {
                            BlackSmithActions();
                        }
                    }
                }

                if (unitsAlive >= bank.UnitLimit)
                {
                    Build(uLib.peasants[0], UnitType.House);
                }
            }
        }
       

    }
    public void ShouldWeAttack()
    {
        
        int units = uLib.archers.Count+uLib.menAtArms.Count;
        //Debug.Log(units);
        if (units >= amountToAttack)
        {
            Debug.Log("Got Here");
            Attack();
        }

    }

    private void ResourceCollectorDelegator(int amount, ResourceType type)
    {
        foreach (var peasant in uLib.peasants)
        {
            if (peasant.currentAction == UnitActions.Nothing)
            {
                
                peasant.BuilderActions.SearchForResource(type);
                amount++;
                if (amount == 2)
                {
                    break;
                }
            }
        }
    }

    private void EditWorkers()
    {
        amountCollectingWood = 0;
        amountFarming = 0;
        amountMining = 0;
        foreach (var peasant in uLib.peasants)
        {
            if (peasant.currentAction == UnitActions.ChopTree)
            {
                amountCollectingWood++;
            }
            else if (peasant.currentAction == UnitActions.Farm)
            {
                amountFarming++;
            }
            else if (peasant.currentAction == UnitActions.Mine)
            {
                amountMining++;
            }
        }
    }

    private void EnsureExtraPeasants(int farmersNeeded, int treeChoppersNeeded)
    {
        if (uLib.peasants.Count > farmersNeeded + treeChoppersNeeded)
        {
            treeChoppersNeeded--;
        }
        if (uLib.peasants.Count > 7)
        {
            treeChoppersNeeded--;
        }
        if (uLib.peasants.Count > 9)
        {
            treeChoppersNeeded--;
            farmersNeeded--;
        }
    }

    private void TrainingFieldActions()
    {
        if (uLib.trainingFields.Count > 0)
        {
            if (uLib.menAtArms.Count < 12)
            {
                foreach (var trainingField in uLib.trainingFields)
                {
                    if (trainingField.BuildingActions.isBuilt == true && trainingField.currentAction == UnitActions.Nothing)
                    {
                        if (bank.Food >= 50 && bank.UnitLimit > unitsAlive)
                        {
                            if (!trainingField.isCurrentlyBuilding && trainingField.BuildingActions.isBuilt)
                            {
                                trainingField.BuildingActions.BuildUnit(trainingField.UnitGameObjects[0], false);
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
        ShouldWeAttack();
    }

    private void CastleActions()
    {
        if (uLib.peasants.Count < 12)
        {
            if (bank.UnitLimit > unitsAlive && bank.Food >= 50)
            {
                GuyMovement castle = uLib.castles[0];
                if (castle.currentAction == UnitActions.Nothing)
                {
                    castle.BuildingActions.BuildUnit(castle.UnitGameObjects[0], false);
                }
            }
        }
    }

    private void BlackSmithActions()
    {
        
        GuyMovement blackSmith = uLib.blackSmiths[0];
        Building blacksmithBuilding = blackSmith.BuildingActions;
        if (blackSmith.currentAction == UnitActions.Nothing)
        {
            //RIGHT HERE
            blacksmithBuilding.Research(blacksmithBuilding.researchableTechnology[0]);
        }
    }

    private void PeasantActions(int farmersNeeded, int treeChoppersNeeded, int minersNeeded, int farming, int collectingWood)
    {
       
    }

    void Build(GuyMovement peasant, UnitType type)
    {
        if (peasant.currentAction != UnitActions.Build)
        {


            //peasant.BuilderActions.basicBuilding = peasant.UnitGameObjects[number];
            Vector3 buildPos = peasant.BuilderActions.SearchForPlaceToBuild(type);
            if (buildPos != Vector3.zero)
            {
                peasant.BuilderActions.BuildBuilding(buildPos);
            }
        }
    }


    private void Attack()
    {
        isAttacking = true;
        int i = 0;
        foreach (var unit in uLib.menAtArms) 
        {
            i++;
            unit.Move(targetCoordinate);           
        }
        foreach (var unit in uLib.archers)
        {
            i++;
            unit.Move(targetCoordinate);
        }

    }
}
