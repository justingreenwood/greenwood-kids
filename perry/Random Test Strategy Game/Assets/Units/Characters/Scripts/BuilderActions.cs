using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BuilderActions : MonoBehaviour
{

    [SerializeField] public GameObject basicBuilding;
    [SerializeField] float buildSpeed = 0.05f;
    [SerializeField] float miningSpeed = 4.5f;

    GuyMovement guyMovement;
    PlayerController playerController;
    ComputerController computerController;
    ResourceBank bank;
    BuildingGrid buildGrid;
    FarmlandActions farmland;
    public GameObject newBuilding;

    float buildRange = 5.5f;
    float harvestRange = 3f;
    float moveDelay;
    
    int gridSize = 4;

    private void Awake()
    {
        guyMovement = GetComponent<GuyMovement>();
        
        guyMovement.isABuilder = true;
    }

    private void Update()
    {
        if (!guyMovement.isCollectingResources)
        {
            if (guyMovement.currentAction == UnitActions.ChopTree)
            {
                SearchForResource(ResourceType.Wood);
            }
        }
    }
    void Start()
    {
        playerController = guyMovement.playerController;
        computerController = GetComponentInParent<ComputerController>();
        moveDelay = guyMovement.moveDelay;
        bank = GetComponentInParent<ResourceBank>();
        buildGrid = FindObjectOfType<BuildingGrid>();

    }
   
    public bool BuildBuilding(Vector3 groundPos)
    {      
        GuyMovement building = basicBuilding.GetComponent<GuyMovement>();
        bool willBuild = bank.RemoveResource(building.UnitFoodCost,building.UnitWoodCost, building.UnitGemCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources");
            return false;
        }       
        var rotation = Quaternion.Euler(0, 0, 0);
        groundPos.y += basicBuilding.transform.localScale.y / 2;
        newBuilding = Instantiate(basicBuilding, groundPos, rotation);        
        newBuilding.tag = tag;

        GuyMovement buildingGM = newBuilding.GetComponent<GuyMovement>();
        Building buildingActions = newBuilding.GetComponent<Building>();
        buildingActions.builder = guyMovement;
        buildingActions.hasBuilder = true;

        guyMovement.StopActivities();
        StopAllCoroutines();
        guyMovement.Move(groundPos);
        guyMovement.currentAction = UnitActions.Build;
        guyMovement.isCurrentlyBuilding = true;

        newBuilding.GetComponentInChildren<Renderer>().material = guyMovement.buildingMaterial;
        newBuilding.GetComponent<GuyMovement>().buildingMaterial = guyMovement.buildingMaterial;
        if (tag != "Yellow Team")
        {
            computerController.uLib.AddUnit(newBuilding.GetComponent<GuyMovement>());
        }
        StartCoroutine(ProcessBuild(false));
        return true;
    }

    public void FinishBuild(GameObject building)
    {
        newBuilding = building;
        guyMovement.StopActivities();
        StopAllCoroutines();

        Vector3 groundPos = newBuilding.transform.localPosition;
        groundPos.y = 0;

        guyMovement.Move(groundPos);
        guyMovement.currentAction = UnitActions.Build;
        guyMovement.isCurrentlyBuilding = true;
        StartCoroutine(ProcessBuild(true));
    }
    IEnumerator ProcessBuild(bool isStarted)
    {
        
        GuyMovement buildingGM = newBuilding.GetComponent<GuyMovement>();
        Building buildingActions = newBuilding.GetComponent<Building>();
        
        if (!isStarted)
        {
            buildingActions.builder = guyMovement;
            buildingActions.hasBuilder = true;
            buildingGM.currentHealth = 10;
        }    
        float necessaryBuildingHealth = buildingGM.currentHealth;

        while (necessaryBuildingHealth < buildingGM.maxHealth)
        {
            
            if(newBuilding == null)
            {
                guyMovement.StopActivities();
            }
            yield return new WaitForSeconds(buildSpeed);
            float distance = Vector3.Distance(newBuilding.transform.position, transform.position) - (buildingActions.width / 2);
            if (distance <= buildRange)
            {
                buildingGM.currentHealth += buildingGM.healthIncInc;
                necessaryBuildingHealth += buildingGM.healthIncInc;
                buildingGM.hPNonUIVisAid.EditTMP(buildingGM.currentHealth, buildingGM.maxHealth);
                if (buildingGM.isSelected)
                {
                    guyMovement.displayInfo.EditUnitInfo(buildingGM.currentHealth, buildingGM.maxHealth);             
                }
            }
        }

        if (playerController != null)
        {
            playerController.unitLibrary.AddUnit(newBuilding.GetComponent<GuyMovement>());
        }

        buildingGM.currentHealth = buildingGM.maxHealth;
        buildingGM.hPNonUIVisAid.EditTMP(buildingGM.currentHealth, buildingGM.maxHealth);
        buildingActions.isBuilt = true;
        guyMovement.isCurrentlyBuilding = false;

        if (buildingActions.raisesUnitLimit)
        {
            bank.RaiseUnitLimit();
        }
        guyMovement.currentAction = UnitActions.Nothing;
        buildingActions.hasBuilder = false;
        if (computerController != null)
        {
            computerController.needToCheck = true;
        }
        else
        {
            if (buildingGM.unitType == UnitType.FarmLand)
            {
                CollectResources(buildingGM.GetComponent<Resource>());
            }
            if (buildingGM.unitType == UnitType.BlackSmith || buildingGM.unitType == UnitType.Library)
            {
                playerController.TechInfo.EditViewableTech();
                playerController.EditDisplay();
            }
        }

    }
    public void Repair(GuyMovement target)
    {
        Debug.Log("repair");
        guyMovement.StopActivities();
        guyMovement.Move(target.transform.position);
        StartCoroutine(ProcessRepair(target));
    }

    IEnumerator ProcessRepair(GuyMovement target)
    {
        bool started = false;
        guyMovement.currentAction = UnitActions.Repair;
        while (target.currentHealth < target.maxHealth)
        {
            yield return new WaitForSeconds(0.5f);
            float distance = Vector3.Distance(target.gameObject.transform.position, transform.position);
            if (distance <= buildRange)
            {
                started = true;
                Debug.Log("repairing");
                bank.RemoveResource(0, 1, 0);
                target.currentHealth += target.healthIncInc;
                playerController.EditDisplay();
                if (bank.Wood <= 0)
                {
                    Debug.Log("Out of resources.");
                    break;
                }
            }
            else if(started == true)
            {
                break;
            }
        }
        guyMovement.currentAction = UnitActions.Nothing;

    }
    public void CollectResources(Resource resource)
    {
        guyMovement.StopActivities();
        if (resource.Type == ResourceType.Food)
        {
            FarmlandActions farm = resource.GetComponent<FarmlandActions>();
            if (farm.HasMaxFarmers())
            {
                return;
            }
            else
            {
                farmland = farm;
            }
        }
        StartCoroutine(ProcessCollectResource(resource));
    }
    public IEnumerator ProcessCollectResource(Resource resource)
    {
        
        if (resource.Type == ResourceType.Food)
        {
            guyMovement.currentAction = UnitActions.Farm;
           
            farmland.AddFarmer(this);

        }
        else if (resource.Type == ResourceType.Wood)
        {
            guyMovement.currentAction = UnitActions.ChopTree;
        }
        else
        {
            guyMovement.currentAction = UnitActions.Mine;
        }
        guyMovement.isCollectingResources = true;
        while (resource.AmountOfResource > 0)
        {
            float distance = Vector3.Distance(resource.transform.position, transform.position);
            if (distance > harvestRange)
            {
                Vector3 destination = Vector3.MoveTowards(transform.position, resource.transform.position, distance - harvestRange + 1);
                guyMovement.Move(destination);
                yield return new WaitForSeconds(moveDelay);
            }
            else
            {
                yield return new WaitForSeconds(miningSpeed);
                bank.AddResource(resource.Type, resource.CollectResource(8));
                if(computerController == null)
                {
                    if (playerController.selectedResource != null)
                    {
                        playerController.EditDisplay();
                    }
                }
            }

        }
        if (farmland != null)
        {
            StopFarming();
        }
        else
        {
            guyMovement.isCollectingResources = false;
        }
    }
    public void SearchForResource(ResourceType rType)
    {
        Collider[] potentialResources = Physics.OverlapSphere(transform.position, 50);

        List<Resource> resources = new List<Resource>();
        foreach (Collider c in potentialResources)
        {
            
            if (c.TryGetComponent(out Resource resource))
            {                
                if (resource.Type == rType)
                {
                    if (rType == ResourceType.Food)
                    {
                        FarmlandActions farmland = resource.GetComponent<FarmlandActions>();
                        if (farmland.farmerCount < 4)
                        {
                            resources.Add(resource);
                        }
                    }
                    else
                    {
                        resources.Add(resource);
                    }

                }
            }
        }
        float distance = 50;
        Resource resourceTarget = null;
        foreach (Resource resource in resources)
        {
            if (Vector3.Distance(resource.transform.position, transform.position) < distance)
            {
                resourceTarget = resource;
                distance = Vector3.Distance(resource.transform.position, transform.position);
            }
        }
        if (resourceTarget != null)
        {
            CollectResources(resourceTarget);
        }
        else
        {
           
            guyMovement.currentAction = UnitActions.Nothing;
        }

    }

    public Vector3 SearchForPlaceToBuild(UnitType type)
    {

        for(int i = 0; i<guyMovement.UnitTypes.Count;i++)
        {
            if (guyMovement.UnitTypes[i] == type)
            {
                basicBuilding = guyMovement.UnitGameObjects[i];
                Debug.Log("We will build thingy.");
                break;
            }

        }

        List<Vector2Int> list = new List<Vector2Int>();
        // MATH SECTION
        Vector3 unitPositionToGrid = Vector3.zero;
        unitPositionToGrid.x = Mathf.Floor(transform.position.x / gridSize) * gridSize;
        //unitPositionToGrid.x += gridSize / 2;
        unitPositionToGrid.z = Mathf.Floor(transform.position.z / gridSize) * gridSize;
        //unitPositionToGrid.z += gridSize / 2;
        int minX = Mathf.CeilToInt(unitPositionToGrid.x) - 20;
        if (minX < 0)
        {
            minX = 0;
        }
        int minY = Mathf.CeilToInt(unitPositionToGrid.z) - 20;
        if (minY < 0)
        {
            minY = 0;
        }
        int maxX = Mathf.CeilToInt(unitPositionToGrid.x) + 20;
        if (maxX > 496)
        {
            maxX = 500 - 8;
        }
        int maxY = Mathf.CeilToInt(unitPositionToGrid.z) + 20;
        if (maxY > 496)
        {
            maxY = 500 - 8;
        }
        // LOOP SECTION
        for (int i = minX; i < maxX; i += 4)
        {
            for (int j = minY; j < maxY; j += 4)
            {
                if (buildGrid.gridSqrsDict.TryGetValue(new Vector2Int(i, j), out bool isClaimed))
                {
                    if (isClaimed == false)
                    {
                        bool continueForth = true;
                        if (buildGrid.gridSqrsDict.TryGetValue(new Vector2Int(i - 4, j), out bool value))
                        {
                            if (value == true)
                            {
                                continueForth = false;
                            }
                        }
                        else
                        {
                            continueForth = false;
                        }
                        if (continueForth == true && buildGrid.gridSqrsDict.TryGetValue(new Vector2Int(i, j - 4), out bool value0))
                        {
                            if (value0 == true)
                            {
                                continueForth = false;
                            }
                        }
                        else
                        {
                            continueForth = false;
                        }
                        if (continueForth == true && buildGrid.gridSqrsDict.TryGetValue(new Vector2Int(i - 4, j - 4), out bool value1))
                        {
                            
                            if (value1 != true)
                            {
                                list.Add(new Vector2Int(i, j));
                            }
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

        if (list.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, list.Count);
            Vector3 returnValue = new Vector3(list[random].x, 0f, list[random].y);

            if(type == UnitType.House|| type == UnitType.Tower || type == UnitType.WizardTower)
            {
                returnValue.x -= 2;
                returnValue.z -= 2;
            }
            //Debug.Log("The value is: "+ returnValue);
            return returnValue;
        }
        else
        {
            return Vector3.zero;
        }

    }
    public void SetNewUnitDestination(Vector3 position)
    {
        guyMovement.destination = position;
    }

    public void StopActions()
    {
        guyMovement.currentAction = UnitActions.Nothing;
        guyMovement.isCollectingResources = false;
        StopAllCoroutines();
    }

    public void StopFarming()
    {
        farmland.RemoveMe(this);
        farmland = null;
        StopActions();
    }


}
