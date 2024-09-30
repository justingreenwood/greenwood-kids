using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class GuyMovement : MonoBehaviour
{

    [SerializeField] int maxHealth = 50;
    public int MaxHealth { get { return maxHealth; } }
    [SerializeField] int currentHealth = 0;
    public int CurrentHealth { get { return currentHealth; } }
    [SerializeField] int healthIncreaseIncrement = 2;

    [SerializeField] int armor = 0;
    public int Armor { get { return armor; } }
    [SerializeField] float attackRange = 10;
    [SerializeField] int attackDamage = 5;
    public int AttackDamage { get { return attackDamage; } }
    [SerializeField] float attackSpeed = 0.75f;
    [SerializeField] float buildSpeed = 0.05f;
    [SerializeField] float miningSpeed = 4.5f;
    [SerializeField] float timeTakenToBuild = 20f;
    [SerializeField] float buildingTimeLeft = 0;
    [SerializeField] float moveDelay = 0.5f;
    [SerializeField] float sightRange = 20f;
    [SerializeField] public UnitType unitType;

    [SerializeField] public bool isMovable = true;
    [SerializeField] public bool isABuilding = false;
    [SerializeField] public bool isBuilder = false;
    [SerializeField] public bool isBuilt = false;
    [SerializeField] public bool targetsNearestEnemy = false;
    [SerializeField] public bool isSelected = false;
    [SerializeField] public Sprite unitImage;

    [SerializeField] public bool canProduceUnits = true;
    [SerializeField] public GameObject basicBuilding;
    [SerializeField] public Material buildingMaterial;
    [SerializeField] int gridSize = 4;
    [SerializeField] public int width = 8;

    [SerializeField]  bool hasUnitWorth = false;
    public bool HasUnitWorth {  get { return hasUnitWorth; } }

    [SerializeField] List<UnitType> unitTypes;
    [SerializeField] List<GameObject> unitGameObjects;
    public List<GameObject> UnitGameObjects { get { return unitGameObjects; } }
    public List<UnitType> UnitTypes { get { return unitTypes; } }

    Vector2Int vTwoPosition;

    [SerializeField] int unitWoodCost = 0;
    [SerializeField] int unitGemCost = 0;
    [SerializeField] int unitFoodCost = 0;
    [SerializeField] int unitSize = 1;
    public int UnitWoodCost { get { return unitWoodCost; } }
    public int UnitFoodCost { get { return unitFoodCost; } }
    public int UnitGemCost { get { return unitGemCost; } }
    public NavMeshAgent agent;
    PlayerController playerController;
    ComputerController computerController;
    GameObject player;
    ResourceBank bank;

    [SerializeField] public GameObject target = null;

    bool isCurrentlyBuilding = false;
    public bool IsCurrentlyBuilding { get { return isCurrentlyBuilding; } }
    public bool isCollectingResources = false;
    bool moveActionOn = false;

    DisplayInformationToScreen displayInfo;

    Vector3 destination = Vector3.zero;

    BuildingGrid buildGrid;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        if (CompareTag(player.tag))
        {
            transform.parent = player.transform;
            bank = player.GetComponent<ResourceBank>();
        }
        else
        {
            transform.parent = FindObjectOfType<ComputerController>().transform;
            computerController = GetComponentInParent<ComputerController>();
            bank = computerController.GetComponent<ResourceBank>();


        }
        displayInfo = playerController.DisplayInfo();

        if (isABuilding)
        {
            buildGrid = FindObjectOfType<BuildingGrid>();
            vTwoPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x) - width / 2, Mathf.RoundToInt(transform.position.z) - width / 2);
            foreach (GridSquares i in buildGrid.gridSquares)
            {
                if (i.position == vTwoPosition)
                {
                    i.isClaimed = true;
                    //Debug.Log(i.position+ ": " + i.isClaimed);
                    break;
                }
            }
            //Debug.Log("V2Pos: " + vTwoPosition);
        }
    }

    private void Update()
    {
        if (targetsNearestEnemy && target == null && !moveActionOn)
        {
            SearchForTarget();
        }

        if(isCurrentlyBuilding == false && isBuilt) 
        {
            if (unitQueue.Count > 0)
            {
                BuildUnit(unitQueue[0]);
            }
        }

    }
    public List<GameObject> unitQueue = new List<GameObject>();
    public void RemoveUnitFromQueue(int i)
    {
        if (i == 0)
        {
            StoppingActivities();
            playerController.unitsAlive -= unitQueue[i].GetComponent<GuyMovement>().unitSize;
            bank.ResetResources();
        }
        unitQueue.RemoveAt(i);
        

    }

    public void AddToQueue(GameObject target)
    {
        if (unitQueue.Count < 5)
        {
            unitQueue.Add(target);
        }
    }

    private void SearchForTarget()
    {

        Collider[] potentialEnemies = Physics.OverlapSphere(transform.position, sightRange);
        List<GameObject> enemies = new List<GameObject>();
        foreach (Collider c in potentialEnemies)
        {
            if (c.gameObject.tag != tag)
            {
                enemies.Add(c.gameObject);

            }
        }
        int amount = enemies.Count;
        for (int i = 0; i < amount; i++)
        {
            if (enemies[i].TryGetComponent(out GuyMovement g) == false)
            {
                enemies.Remove(enemies[i]);
                i--;
                amount--;
            }
        }
        float distance = sightRange;
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < distance)
            {
                target = enemy;
                distance = Vector3.Distance(target.transform.position, transform.position);
            }
        }
        if (target != null)
        {
            Attack(target.GetComponent<GuyMovement>());
        }

    }

    public void Move(Vector3? groundLocation)
    {
        if (isMovable)
            agent.SetDestination(groundLocation.Value);
        else
        {
            SetNewUnitDestination(groundLocation.Value);
        }
    }

    public void MoveActionWait()
    {
        moveActionOn = true;
        StartCoroutine(MoveActionCoolDown());
    }

    IEnumerator MoveActionCoolDown()
    {
        yield return new WaitForSeconds(4);
        moveActionOn = false;
    }

    public void Attack(GuyMovement enemy)
    {
        StoppingActivities();
        StartCoroutine(ProcessAttack(enemy));
    }

    IEnumerator ProcessAttack(GuyMovement target)
    {
        
        while(target.currentHealth > 0)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance > attackRange)
            {
                UnityEngine.Debug.Log("Moving");
                Vector3 destination = Vector3.MoveTowards(transform.position, target.transform.position, distance - attackRange + 1);
                Move(destination);
                yield return new WaitForSeconds(moveDelay);
            }
            else
            {
                UnityEngine.Debug.Log("Pew Pew");
                target.TakeDamage(attackDamage);
                yield return new WaitForSeconds(attackSpeed);
            }
            
        }
        
    }

    public void SetNewUnitDestination(Vector3 position)
    {
        destination = position;
    }

    public void Build(GameObject objectPrefab, Material material, Vector3 groundPos)
    {
        
        var rotation = Quaternion.Euler(0, 0, 0);
        groundPos.y += objectPrefab.transform.localScale.y / 2;
        GameObject newGameObject = Instantiate(objectPrefab, groundPos, rotation);
        newGameObject.tag = tag;
        newGameObject.GetComponentInChildren<Renderer>().material = material;

        if(destination != Vector3.zero)
        {
            newGameObject.GetComponent<GuyMovement>().isBuilt = true;
            newGameObject.GetComponent<GuyMovement>().Move(destination);
        }


    }
    public bool BuildBuilding(Vector3 groundPos)
    {
        StoppingActivities();
        GuyMovement building = basicBuilding.GetComponent<GuyMovement>();
        bool willBuild = bank.RemoveResource(building.UnitWoodCost, building.unitGemCost, building.UnitFoodCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources");
            return false;
        }

        isCurrentlyBuilding = true;
        var rotation = Quaternion.Euler(0, 0, 0);
        groundPos.y += basicBuilding.transform.localScale.y / 2;
        GameObject newBuilding = Instantiate(basicBuilding, groundPos, rotation);
        newBuilding.tag = tag;
        newBuilding.GetComponentInChildren<Renderer>().material = buildingMaterial;

        //Debug.Log("Ground Pos: "+ groundPos);
        StartCoroutine(ProcessBuild(newBuilding));
        return true;
    }

    IEnumerator ProcessBuild(GameObject newBuilding)
    {
        GuyMovement buildingActions = newBuilding.GetComponent<GuyMovement>();

        int necessaryBuildingHealth = buildingActions.currentHealth;

        

        while (necessaryBuildingHealth < buildingActions.maxHealth) 
        {
            yield return new WaitForSeconds(buildingActions.buildSpeed);
            float distance = Vector3.Distance(newBuilding.transform.position, transform.position)-(buildingActions.width/2);
            if (distance <= attackRange)
            {
                buildingActions.currentHealth += buildingActions.healthIncreaseIncrement;
                necessaryBuildingHealth += buildingActions.healthIncreaseIncrement;
                if (buildingActions.isSelected)
                {
                    displayInfo.EditUnitInfo(buildingActions.currentHealth, buildingActions.maxHealth);
                }
            }
        }
        buildingActions.currentHealth = buildingActions.MaxHealth;
        buildingActions.isBuilt = true;
        isCurrentlyBuilding = false;
        if (buildingActions.hasUnitWorth)
        {
            bank.RaiseUnitLimit();
        }
        if (buildingActions.isSelected)
        {
            displayInfo.EditUnitInfo(buildingActions.currentHealth, buildingActions.maxHealth);
        }

    }

    IEnumerator ProcessBuildUnit(GameObject chosenUnit)
    {
        isCurrentlyBuilding = true;
        float x = 0;
        while(x<=timeTakenToBuild)
        {

            yield return new WaitForSeconds(buildSpeed);
            x += buildSpeed;
            buildingTimeLeft = timeTakenToBuild - x;
        }

        Vector3 pos = transform.position;
        pos.x = transform.position.x + 1 / transform.localScale.x;
        pos.x += 2;
        Build(chosenUnit, buildingMaterial, pos);
        bank.ResetBorrowedResources();
        unitQueue.Remove(chosenUnit);

        playerController.EditDisplay();
        isCurrentlyBuilding = false;

    }
    public void Repair(GuyMovement target)
    {
        StoppingActivities();
        Move(target.transform.position);
        StartCoroutine(ProcessRepair(target));
    }

    IEnumerator ProcessRepair(GuyMovement target)
    {
        while(target.currentHealth < target.maxHealth)
        {
            yield return new WaitForSeconds(buildSpeed);
            float distance = Vector3.Distance(target.gameObject.transform.position, transform.position);
            if (distance <= attackRange)
            {
                bank.RemoveResource(1, 0, 0);
                target.currentHealth += healthIncreaseIncrement;
                if(bank.Wood<=0)
                {
                    UnityEngine.Debug.Log("Out of resources.");
                    break;
                }
            }
        }
        //target.currentHealth = target.maxHealth;

    }
    public bool BuildUnit(GameObject chosenUnit)
    {
        GuyMovement chosenGuyM = chosenUnit.GetComponent<GuyMovement>();
        bool willBuild = bank.HasEnoughResource(chosenGuyM.UnitWoodCost, chosenGuyM.unitGemCost, chosenGuyM.UnitFoodCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources");

            return false;
        }
        bank.RemoveResource(chosenGuyM.UnitWoodCost, chosenGuyM.unitGemCost, chosenGuyM.UnitFoodCost);
        bank.BorrowedResources(chosenGuyM.UnitWoodCost, chosenGuyM.unitGemCost, chosenGuyM.UnitFoodCost);
        if (CompareTag(player.tag))
            playerController.unitsAlive++;
        else
        {

        }

        StoppingActivities();
        StartCoroutine(ProcessBuildUnit(chosenUnit));
        return true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            if (CompareTag(player.tag))
            {
                if (!isABuilding)
                {
                    playerController.unitsAlive--;
                }
                else if (isABuilding && isCurrentlyBuilding)
                {
                    playerController.unitsAlive--;
                }
                playerController.Deselect(gameObject);
            }
            if (hasUnitWorth)
            {
                bank.LowerUnitLimit();
            }

            if (isABuilding)
            {
                foreach (var i in buildGrid.gridSquares)
                {
                    if (i.position == vTwoPosition)
                    {
                        i.isClaimed = false;
                    }
                }
            }

            Destroy(gameObject);
        }
        else if(isSelected)
        {
            displayInfo.EditUnitInfo(currentHealth, maxHealth);
        }
    }

    public void CollectResources(Resource resource)
    {
        StoppingActivities();
        StartCoroutine(ProcessCollectResource(resource));
    }

    public IEnumerator ProcessCollectResource(Resource resource)
    {
        isCollectingResources = true;
        while (resource.Resources>0)
        {
            float distance = Vector3.Distance(resource.transform.position, transform.position);
            if (distance > attackRange)
            {
                UnityEngine.Debug.Log("Moving");
                Vector3 destination = Vector3.MoveTowards(transform.position, resource.transform.position, distance - attackRange + 1);
                Move(destination);
                yield return new WaitForSeconds(moveDelay);
            }
            else
            {
                yield return new WaitForSeconds(miningSpeed);
                bank.AddResource(resource.Type, resource.CollectResource(8));
            }
            
        }
        isCollectingResources = false;
    }

    public void StoppingActivities()
    {
        isCollectingResources = false;
        isCurrentlyBuilding = false;
        StopAllCoroutines();
    }


}
