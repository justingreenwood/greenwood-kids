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
    public bool mayNeedToAttack = false;
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
    
    [SerializeField] UnitType currentTask = UnitType.None;
    int currentWoodGoal = 0;
    int currentFoodGoal = 0;
    int currentGemGoal = 0;
    bool needWood = false;
    bool needFood = false;
    bool needGems = false;
    bool taskStarted = false;
    bool ignorePS = false;
    bool haveAnUnfinishedBuilding = false;

    bool needCollectors = true;

    Building unfinishedBuilding = null;

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

        if (mayNeedToAttack)
        {
            ShouldWeAttack();
            mayNeedToAttack = false;
        }

        if(haveAnUnfinishedBuilding)
        {
            foreach(GuyMovement peasant in uLib.peasants)
            {
                if(peasant.currentAction != UnitActions.Build)
                {
                    peasant.BuilderActions.FinishBuild(unfinishedBuilding.gameObject);
                    haveAnUnfinishedBuilding=false;
                    unfinishedBuilding = null;
                    break;
                }
            }
        }

        if (uLib.castles.Count >= 1)
        {
            CastleActions();
        }
        if (uLib.trainingFields.Count >= 1)
        {
            TrainingFieldActions();
        }
        if (uLib.blackSmiths.Count >= 1)
        {
            BlackSmithActions();
        }
        if (uLib.libraries.Count >= 1)
        {
            LibraryActions();
        }
        if (uLib.stables.Count >= 1)
        {
            StablesActions();
        }
        if (uLib.pegasusStables.Count >= 1)
        {
            PegasusStablesActions();
        }
        if (uLib.wizardTowers.Count >= 1)
        {
            WizardTowerActions();
        }
        if (currentTask == UnitType.None)
        {
            Debug.Log("We need a task.");
            if (uLib.castles.Count < 1)
            {
                currentTask = UnitType.Castle;
                currentWoodGoal = 1000;
            }
            else if (uLib.farmland.Count < 1)
            {
                Debug.Log("We need some farmland.");
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
                Debug.Log("We need a blacksmith.");
                currentTask = UnitType.BlackSmith;
                currentWoodGoal = 250;
                currentGemGoal = 100;
            }
            else if (uLib.trainingFields.Count < 2)
            {
                Debug.Log("We need a training field.");
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
            else if (uLib.pegasusStables.Count < 1 && !ignorePS)
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

        if (currentTask != UnitType.None && !taskStarted)
        {
            Debug.Log("I am starting the task.");
            StartTask(currentTask);
        }
        else if (currentTask != UnitType.None && taskStarted)
        {
            if (DoWeMeetRequirements())
            {
                Debug.Log("We have what we need.");
                if (currentTask == UnitType.PegasusStables)
                {
                    Building buildingActions = uLib.stables[0].GetComponent<GuyMovement>().BuildingActions;
                    if (buildingActions.isBuilt && buildingActions.GMovement.currentAction == UnitActions.Nothing)
                    {
                        bool success = buildingActions.UpgradeBuilding();
                        if (success)
                        {
                            ignorePS = true;
                            ResetGoal();
                        }
                        Debug.Log("Task Completed!");
                    }
                }
                else
                {
                    foreach (var peasant in uLib.peasants)
                    {
                        if (peasant.currentAction != UnitActions.Build)
                        {
                            bool success = Build(peasant, currentTask);
                            if (success)
                            {
                                if (currentTask == UnitType.BlackSmith || currentTask == UnitType.Library)
                                {
                                    techInfo.EditViewableTech();
                                }
                                ResetGoal();
                            }
                            Debug.Log("Task Completed!");
                            break;
                        }

                    }
                }

            }
        }
    }
    void StartTask(UnitType type)
    {

        if(currentWoodGoal > 0)
        {
            needWood = true;
        }
        if (currentFoodGoal > 0)
        {
            needFood = true;
        }
        if(currentGemGoal > 0)
        {
            needGems = true;
        }
        if (uLib.peasants.Count >= 1)
        {
            RetaskWorkers(needWood,needFood,needGems);
            taskStarted = true;
            Debug.Log("Task Started");
        }
    }

    private void RetaskWorkers(bool nWood, bool nFood, bool nGems)
    {
        bool requiresOneMin = false;
        if (uLib.peasants.Count >= 5)
        {
            requiresOneMin = true;
        }
        foreach (var peasant in uLib.peasants)
        {
            
            if (peasant.currentAction != UnitActions.Build)
            {
                peasant.StopActivities();
                if (requiresOneMin)
                {
                    if (amountCollectingWood == 0)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Wood);
                    }
                    else if (amountFarming == 0)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Food);
                    }
                    else if (amountMining == 0)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Gems);
                    }
                }
                if (nWood && nFood && nGems)
                {
                    if (amountCollectingWood < amountFarming)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Wood);
                    }
                    else if (amountFarming < amountMining)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Food);
                    }
                    else
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Gems);
                    }
                }
                else if (nWood && nFood)
                {
                    if (amountCollectingWood < amountFarming)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Wood);
                    }
                    else
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Food);
                    }
                }
                else if (nWood && nGems)
                {
                    if (amountCollectingWood < amountMining)
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Wood);
                    }
                    else
                    {
                        peasant.BuilderActions.SearchForResource(ResourceType.Gems);
                    }
                }
                else if (nWood)
                {
                    peasant.BuilderActions.SearchForResource(ResourceType.Wood);
                }
            }
        }
        EditWorkers();
    }

    void ResetGoal()
    {
        currentFoodGoal = 0;
        currentGemGoal = 0;
        currentWoodGoal = 0;
        needWood = false;
        needFood = false;
        needGems = false;
        currentTask = UnitType.None;
        taskStarted = false;
    }
    bool DoWeMeetRequirements()
    {
        bool haveEnoughFood = true;
        bool haveEnoughWood = true;
        bool haveEnoughGems = true;
        if (needFood)
        {
            if (currentFoodGoal > bank.Food)
            {
                haveEnoughFood = false;
            }            
        }
        if(needWood)
        {
            if(currentWoodGoal> bank.Wood)
            {
                haveEnoughWood = false;
            }
        }
        if (needGems)
        {
            if(currentGemGoal > bank.Gems)
            {
                haveEnoughGems = false;
            }
        }
        if (haveEnoughFood && haveEnoughGems && haveEnoughWood)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ShouldWeAttack()
    {    
        int units = uLib.archers.Count+uLib.menAtArms.Count;
        if (units >= amountToAttack)
        {
            // Attack();
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

    public void NeedBuilder(Building building)
    {
        haveAnUnfinishedBuilding = true;
        unfinishedBuilding = building;
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
            if (uLib.menAtArms.Count < 12 || uLib.archers.Count<8)
            {
                foreach (var trainingField in uLib.trainingFields)
                {
                    if (trainingField.BuildingActions.isBuilt == true && trainingField.currentAction == UnitActions.Nothing)
                    {
                        if (uLib.menAtArms.Count < 6)
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
                        else if(uLib.archers.Count < 4)
                        {
                            if (bank.Food >= 50 && bank.Wood >= 20 && bank.UnitLimit > unitsAlive)
                            {
                                if (!trainingField.isCurrentlyBuilding && trainingField.BuildingActions.isBuilt)
                                {
                                    trainingField.BuildingActions.BuildUnit(trainingField.UnitGameObjects[1], false);
                                    unitsAlive++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (uLib.menAtArms.Count < 12)
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
                        else if (uLib.archers.Count < 16)
                        {
                            if (bank.Food >= 50 && bank.Wood >= 20 && bank.UnitLimit > unitsAlive)
                            {
                                if (!trainingField.isCurrentlyBuilding && trainingField.BuildingActions.isBuilt)
                                {
                                    trainingField.BuildingActions.BuildUnit(trainingField.UnitGameObjects[1], false);
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

    private void StablesActions()
    {
        if (uLib.trainingFields.Count > 0)
        {
            if (uLib.knights.Count < 12 || uLib.rangedCavalry.Count < 8)
            {
                foreach (var stables in uLib.stables)
                {
                    if (currentTask != UnitType.PegasusStables)
                    {
                        if (stables.BuildingActions.isBuilt == true && stables.currentAction == UnitActions.Nothing)
                        {
                            if(uLib.knights.Count < 6)
                            {
                                if (bank.Food >= 200 && bank.Wood >= 25 && bank.UnitLimit > unitsAlive)
                                {
                                    if (!stables.isCurrentlyBuilding && stables.BuildingActions.isBuilt)
                                    {
                                        stables.BuildingActions.BuildUnit(stables.UnitGameObjects[2], false);
                                        unitsAlive++;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (uLib.rangedCavalry.Count < 4)
                            {
                                if (bank.Food >= 100 && bank.Wood >= 20 && bank.UnitLimit > unitsAlive)
                                {
                                    if (!stables.isCurrentlyBuilding && stables.BuildingActions.isBuilt)
                                    {
                                        stables.BuildingActions.BuildUnit(stables.UnitGameObjects[1], false);
                                        unitsAlive++;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (uLib.knights.Count < 12)
                            {
                                if (bank.Food >= 200 && bank.Wood >= 25 && bank.UnitLimit > unitsAlive)
                                {
                                    if (!stables.isCurrentlyBuilding && stables.BuildingActions.isBuilt)
                                    {
                                        stables.BuildingActions.BuildUnit(stables.UnitGameObjects[2], false);
                                        unitsAlive++;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (uLib.rangedCavalry.Count < 8)
                            {
                                if (bank.Food >= 100 && bank.Wood >= 20 && bank.UnitLimit > unitsAlive)
                                {
                                    if (!stables.isCurrentlyBuilding && stables.BuildingActions.isBuilt)
                                    {
                                        stables.BuildingActions.BuildUnit(stables.UnitGameObjects[1], false);
                                        unitsAlive++;
                                    }
                                }
                                else
                                {
                                    break;
                                }
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
    }
    private void PegasusStablesActions()
    {
        if (uLib.trainingFields.Count > 0)
        {
            if (uLib.pegasusArchers.Count < 12)
            {
                foreach (var stables in uLib.stables)
                {
                    if (currentTask != UnitType.PegasusStables)
                    {
                        if (stables.BuildingActions.isBuilt == true && stables.currentAction == UnitActions.Nothing)
                        {
                            if (bank.Food >= 200 && bank.Wood >= 25 && bank.UnitLimit > unitsAlive)
                            {
                                if (!stables.isCurrentlyBuilding && stables.BuildingActions.isBuilt)
                                {
                                    stables.BuildingActions.BuildUnit(stables.UnitGameObjects[2], false);
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
    }
    private void WizardTowerActions()
    {
        if (uLib.trainingFields.Count > 0)
        {
            if (uLib.dragons.Count < 6 || uLib.wizards.Count < 8)
            {
                foreach (var towers in uLib.wizardTowers)
                {
                    if (towers.BuildingActions.isBuilt == true && towers.currentAction == UnitActions.Nothing)
                    {
                        if (uLib.wizards.Count < 4)
                        {
                            if (bank.Food >= 40 && bank.Wood >= 15 && bank.Gems >= 150 && bank.UnitLimit > unitsAlive)
                            {
                                if (!towers.isCurrentlyBuilding && towers.BuildingActions.isBuilt)
                                {
                                    towers.BuildingActions.BuildUnit(towers.UnitGameObjects[0], false);
                                    unitsAlive++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (uLib.dragons.Count < 3)
                        {
                            if (bank.Food >= 300 && bank.Wood >= 50 && bank.Gems >= 250 && bank.UnitLimit > unitsAlive)
                            {
                                if (!towers.isCurrentlyBuilding && towers.BuildingActions.isBuilt)
                                {
                                    towers.BuildingActions.BuildUnit(towers.UnitGameObjects[1], false);
                                    unitsAlive++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (uLib.wizards.Count < 8)
                        {
                            if (bank.Food >= 40 && bank.Wood >= 15 && bank.Gems >= 150 && bank.UnitLimit > unitsAlive)
                            {
                                if (!towers.isCurrentlyBuilding && towers.BuildingActions.isBuilt)
                                {
                                    towers.BuildingActions.BuildUnit(towers.UnitGameObjects[0], false);
                                    unitsAlive++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (uLib.dragons.Count < 6)
                        {
                            if (bank.Food >= 300 && bank.Wood >= 50 && bank.Gems >= 250 && bank.UnitLimit > unitsAlive)
                            {
                                if (!towers.isCurrentlyBuilding && towers.BuildingActions.isBuilt)
                                {
                                    towers.BuildingActions.BuildUnit(towers.UnitGameObjects[1], false);
                                    unitsAlive++;
                                }
                            }
                            else
                            {
                                break;
                            }
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

    bool Build(GuyMovement peasant, UnitType type)
    {
        bool successful = false;
        if (peasant.currentAction != UnitActions.Build)
        {          
            //peasant.BuilderActions.basicBuilding = peasant.UnitGameObjects[number];
            Vector3 buildPos = peasant.BuilderActions.SearchForPlaceToBuild(type);
            if (buildPos != Vector3.zero && buildPos!= null)
            {
                successful = peasant.BuilderActions.BuildBuilding(buildPos);
            }
        }
        return successful;
    }


    private void Attack()
    {
        isAttacking = true;
        int i = 0;
        if (uLib.menAtArms.Count > 0)
        {
            foreach (var unit in uLib.menAtArms)
            {
                i++;
                unit.Move(targetCoordinate);
            }
        }
        if (uLib.archers.Count > 0)
        {
            foreach (var unit in uLib.archers)
            {
                i++;
                unit.Move(targetCoordinate);
            }
        }

    }
    public void GetJob(GuyMovement peasant)
    {

        if (needWood && needFood && needGems)
        {
            if (amountCollectingWood < amountFarming)
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Wood);
            }
            else if (amountFarming < amountMining)
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Food);
            }
            else
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Gems);
            }
        }
        else if (needWood && needFood)
        {
            if (amountCollectingWood < amountFarming)
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Wood);
            }
            else
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Food);
            }
        }
        else if (needWood && needGems)
        {
            if (amountCollectingWood < amountMining)
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Wood);
            }
            else
            {
                peasant.BuilderActions.SearchForResource(ResourceType.Gems);
            }
        }
        else if (needWood)
        {
            peasant.BuilderActions.SearchForResource(ResourceType.Wood);
        }
        EditWorkers();
    }
}
