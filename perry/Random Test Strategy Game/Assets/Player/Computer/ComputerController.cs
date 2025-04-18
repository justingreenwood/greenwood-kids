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
    
    UnitType currentTask;
    int currentWoodGoal = 0;
    int currentFoodGoal = 0;
    int currentGemGoal = 0;
    bool taskStarted = false;



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
        if (currentTask == UnitType.None)
        {   if (uLib.castles.Count < 1)
            {
                currentTask = UnitType.Castle;
                currentWoodGoal = 1000;
            }
            else if (uLib.farmland.Count < 1)
            {
                currentTask = UnitType.FarmLand;
                currentWoodGoal = 100;
            }
            else if (uLib.houses.Count < 1)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.trainingFields.Count < 1)
            {
                currentTask = UnitType.TrainingField;
                currentWoodGoal = 150;
            }
            else if (uLib.houses.Count < 2)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.stables.Count < 1)
            {
                currentTask = UnitType.Stables;
                currentWoodGoal = 250;
                currentFoodGoal = 200;
            }
            else if (uLib.houses.Count < 3)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.blackSmiths.Count < 1)
            {
                currentTask = UnitType.BlackSmith;
                currentWoodGoal = 250;
                currentGemGoal = 100;
            }
            else if (uLib.trainingFields.Count < 2)
            {
                currentTask = UnitType.TrainingField;
                currentWoodGoal = 150;
            }
            else if (uLib.houses.Count < 4)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.libraries.Count < 1)
            {
                currentTask = UnitType.Library;
                currentWoodGoal = 3000;
                currentGemGoal = 200;
            }
            else if (uLib.houses.Count < 5)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.pegasusStables.Count < 1)
            {
                currentTask = UnitType.PegasusStables;
                currentWoodGoal = 300;
                currentGemGoal = 50;
                currentFoodGoal = 200;
            }
            else if (uLib.houses.Count < 6)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.wizardTowers.Count < 1)
            {
                currentTask = UnitType.WizardTower;
                currentWoodGoal = 200;
                currentGemGoal = 300;
                currentFoodGoal = 100;
            }
            else if (uLib.houses.Count < 6)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }            
            else if (uLib.wizardTowers.Count < 2)
            {
                currentTask = UnitType.WizardTower;
                currentWoodGoal = 200;
                currentGemGoal = 300;
                currentFoodGoal = 100;
            }
            else if (uLib.houses.Count < 7)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
            else if (uLib.towers.Count < 4)
            {
                currentTask = UnitType.Tower;
                currentWoodGoal = 200;
            }
            else if (uLib.houses.Count < 8)
            {
                currentTask = UnitType.House;
                currentWoodGoal = 100;
            }
        }

        if(currentTask != UnitType.None && !taskStarted)
        {
            StartTask(currentTask);
        }

        if(currentWoodGoal >= bank.Wood && currentGemGoal >= bank.Gems && currentFoodGoal >= bank.Food)
        {
            foreach(var peasant in uLib.peasants)
            {
                if (peasant.currentAction!= UnitActions.Build)
                {
                    Build(peasant, currentTask);
                    ResetGoal();
                    break;
                }

            }
        }
        


        if(uLib.blackSmiths.Count >= 1)
        {
            BlackSmithActions();
        }


    }
    void StartTask(UnitType type)
    {
        
        if (uLib.peasants.Count >= 3)
        {
            foreach (var peasant in uLib.peasants)
            {
                

                if(currentGemGoal != 0)
                {

                    
                }
                
            }
            EditWorkers();
        }
    }
    void ResetGoal()
    {
        currentFoodGoal = 0;
        currentGemGoal = 0;
        currentWoodGoal = 0;
        currentTask = UnitType.None;
        taskStarted = false;
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

    public void BuilderActions(GuyMovement unitAction)
    {

        if (uLib.farmland.Count < 1)
        {
            if(bank.Wood >= 1)
                Build(unitAction, UnitType.FarmLand);
            else
                ResourceCollectorDelegator(amountCollectingWood, ResourceType.Wood);
        }
        else if (uLib.castles.Count < 1)
        {
            if (bank.Wood >= 1)
                Build(unitAction, UnitType.Castle);
            else
                ResourceCollectorDelegator(amountCollectingWood, ResourceType.Wood);
        }
        else if (amountCollectingWood < 1)
        {
            ResourceCollectorDelegator(amountCollectingWood, ResourceType.Wood);
        }
        else if (amountFarming < 1)
        {
            ResourceCollectorDelegator(amountFarming, ResourceType.Food);
        }
        else if (amountMining < 1)
        {
            ResourceCollectorDelegator(amountMining, ResourceType.Gems);
        }
        else
        {
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
            if (blacksmithBuilding.researchableTechnology.Count>0)
            {
                ITech tech = blacksmithBuilding.researchableTechnology[0];
                Debug.Log(tech.techType);
                //RIGHT HERE
                blacksmithBuilding.Research(tech);
            }
        }
    }

    private void LibraryActions()
    {
        GuyMovement library = uLib.libraries[0];
        Building libraryBuilding = library.BuildingActions;
        if (library.currentAction == UnitActions.Nothing)
        {
            if (libraryBuilding.researchableTechnology.Count > 0)
            {
                ITech tech = libraryBuilding.researchableTechnology[0];
                Debug.Log(tech.techType);
                //RIGHT HERE
                libraryBuilding.Research(tech);
            }
        }
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
    public void GetJob(GuyMovement unitAction)
    {
        if(unitAction.unitType == UnitType.Builder)
        {
            BuilderActions(unitAction);
        }
        switch (unitAction.unitType)
        {
            case UnitType.Builder:

                BuilderActions(unitAction);
                break;
            //case UnitType.BlackSmith:

            //    BlackSmithActions(unitAction);
            //    break;
            //case UnitType.Castle:

            //    CastleActions(unitAction);
            //    break;



        }
    }
}
