using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    [SerializeField] public GameObject basicBuilding;
    [SerializeField] float buildSpeed = 0.05f;
    [SerializeField] float miningSpeed = 4.5f;

    GuyMovement guyMovement;
    PlayerController playerController;
    ComputerController computerController;
    ResourceBank bank;
    BuildingGrid buildGrid;

    float actionRange = 5.5f;
    float moveDelay;
    
    int gridSize = 4;

    private void Awake()
    {
        guyMovement = GetComponent<GuyMovement>();
        
        guyMovement.isABuilder = true;
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
        guyMovement.StopActivities();
        StopAllCoroutines();
        guyMovement.Move(groundPos);
        guyMovement.currentAction = UnitActions.Build;
        guyMovement.isCurrentlyBuilding = true;
        var rotation = Quaternion.Euler(0, 0, 0);
        groundPos.y += basicBuilding.transform.localScale.y / 2;
        GameObject newBuilding = Instantiate(basicBuilding, groundPos, rotation);
        building = newBuilding.GetComponent<GuyMovement>();       
        newBuilding.tag = tag;
        newBuilding.GetComponentInChildren<Renderer>().material = guyMovement.buildingMaterial;
        newBuilding.GetComponent<GuyMovement>().buildingMaterial = guyMovement.buildingMaterial;

        if (computerController != null)
        {
            computerController.uLib.AddUnit(newBuilding.GetComponent<GuyMovement>());
        }
        else if (playerController != null)
        {
            playerController.unitLibrary.AddUnit(newBuilding.GetComponent<GuyMovement>());
        }
        StartCoroutine(ProcessBuild(newBuilding));
        return true;
    }

    IEnumerator ProcessBuild(GameObject newBuilding)
    {

        GuyMovement buildingGM = newBuilding.GetComponent<GuyMovement>();
        Building buildingActions = newBuilding.GetComponent<Building>();
        buildingGM.currentHealth = 10;
        float necessaryBuildingHealth = buildingGM.currentHealth;


        while (necessaryBuildingHealth < buildingGM.maxHealth)
        {
            yield return new WaitForSeconds(buildSpeed);
            float distance = Vector3.Distance(newBuilding.transform.position, transform.position) - (buildingActions.width / 2);
            if (distance <= actionRange)
            {
                buildingGM.currentHealth += buildingGM.healthII;
                necessaryBuildingHealth += buildingGM.healthII;
                buildingGM.hPNonUIVisAid.EditTMP(buildingGM.currentHealth, buildingGM.maxHealth);
                if (buildingGM.isSelected)
                {
                    guyMovement.displayInfo.EditUnitInfo(buildingGM.currentHealth, buildingGM.maxHealth);             
                }
            }
        }

        buildingGM.currentHealth = buildingGM.maxHealth;
        buildingGM.hPNonUIVisAid.EditTMP(buildingGM.currentHealth, buildingGM.maxHealth);
        buildingActions.isBuilt = true;
        guyMovement.isCurrentlyBuilding = false;

        bank.RaiseUnitLimit();

        if (computerController != null)
        {
            computerController.needToCheck = true;
        }
        guyMovement.currentAction = UnitActions.Nothing;
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
            if (distance <= actionRange)
            {
                started = true;
                Debug.Log("repairing");
                bank.RemoveResource(0, 1, 0);
                target.currentHealth += target.healthII;
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
        StartCoroutine(ProcessCollectResource(resource));
    }
    public IEnumerator ProcessCollectResource(Resource resource)
    {
        if (resource.Type == ResourceType.Food)
        {
            guyMovement.currentAction = UnitActions.Farm;
            resource.GetComponent<Farmland>().AddFarmer(guyMovement);
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
        while (resource.Resources > 0)
        {
            float distance = Vector3.Distance(resource.transform.position, transform.position);
            if (distance > actionRange)
            {
                Vector3 destination = Vector3.MoveTowards(transform.position, resource.transform.position, distance - actionRange + 1);
                guyMovement.Move(destination);
                yield return new WaitForSeconds(moveDelay);
            }
            else
            {
                yield return new WaitForSeconds(miningSpeed);
                bank.AddResource(resource.Type, resource.CollectResource(8));
            }

        }
        guyMovement.isCollectingResources = false;
        guyMovement.currentAction = UnitActions.Nothing;
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
                    
                    resources.Add(resource);
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

    }

    public Vector3 SearchForPlaceToBuild()
    {
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
            Vector2Int lastV2 = Vector2Int.zero;
            float shortestDist = 1000;
            int home = Mathf.FloorToInt(unitPositionToGrid.x + unitPositionToGrid.z);
            foreach (var v2Int in list)
            {
                float dist = Vector2.Distance(v2Int, new Vector2(unitPositionToGrid.x, unitPositionToGrid.z));
                if (dist < shortestDist)
                {

                    lastV2 = v2Int;
                    shortestDist = dist;
                }
            }
            Vector3 returnValue = new Vector3(lastV2.x, 0.3f, lastV2.y);


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
}
