using System;
using System.Collections;
using System.Collections.Generic;
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


    [SerializeField] int unitWoodCost = 0;
    [SerializeField] int unitGemCost = 0;
    [SerializeField] int unitFoodCost = 0;
    [SerializeField] int unitSize = 1;
    public int UnitWoodCost { get { return unitWoodCost; } }
    public int UnitFoodCost { get { return unitFoodCost; } }
    public int UnitGemCost { get { return unitGemCost; } }
    public NavMeshAgent agent;
    PlayerController playerController;
    GameObject player;
    ResourceBank bank;

    [SerializeField] public GameObject target = null;

    bool isCurrentlyBuilding = false;
    public bool IsCurrentlyBuilding { get { return isCurrentlyBuilding; } }
    bool moveActionOn = false;

    DisplayInformationToScreen displayInfo;

    Vector3 destination = Vector3.zero;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        bank = player.GetComponent<ResourceBank>();
        displayInfo = playerController.DisplayInfo();
    }

    private void Update()
    {
        if (targetsNearestEnemy && target == null && !moveActionOn)
        {
            SearchForTarget();
        }

        if(isCurrentlyBuilding == false) 
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
            StopAllCoroutines();
            playerController.unitsAlive -= unitQueue[i].GetComponent<GuyMovement>().unitSize;
            bank.ResetResources();
            isCurrentlyBuilding = false;
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
        StopAllCoroutines();
        StartCoroutine(ProcessAttack(enemy));
    }

    IEnumerator ProcessAttack(GuyMovement target)
    {
        
        while(target.currentHealth > 0)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance > attackRange)
            {
                Debug.Log("Moving");
                Vector3 destination = Vector3.MoveTowards(transform.position, target.transform.position, distance - attackRange + 1);
                Move(destination);
                yield return new WaitForSeconds(moveDelay);
            }
            else
            {
                Debug.Log("Pew Pew");
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
        StopAllCoroutines();
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
        StopAllCoroutines();
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
                    Debug.Log("Out of resources.");
                    break;
                }
            }
        }
        //target.currentHealth = target.maxHealth;

    }
    public bool BuildUnit(GameObject chosenUnit)
    {
        bool willBuild = bank.HasEnoughResource(basicBuilding.GetComponent<GuyMovement>().UnitWoodCost, basicBuilding.GetComponent<GuyMovement>().unitGemCost, basicBuilding.GetComponent<GuyMovement>().UnitFoodCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources");

            return false;
        }
        bank.RemoveResource(basicBuilding.GetComponent<GuyMovement>().UnitWoodCost, basicBuilding.GetComponent<GuyMovement>().unitGemCost, basicBuilding.GetComponent<GuyMovement>().UnitFoodCost);
        bank.BorrowedResources(basicBuilding.GetComponent<GuyMovement>().UnitWoodCost, basicBuilding.GetComponent<GuyMovement>().unitGemCost, basicBuilding.GetComponent<GuyMovement>().UnitFoodCost);
        playerController.unitsAlive++;

        StopAllCoroutines();
        StartCoroutine(ProcessBuildUnit(chosenUnit));
        return true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            if (CompareTag(playerController.tag))
            {
                if (!isABuilding)
                {
                    playerController.unitsAlive--;
                }
                else if (isABuilding && isCurrentlyBuilding)
                {
                    playerController.unitsAlive--;
                }
            }
            if (hasUnitWorth)
            {
                bank.LowerUnitLimit();
            }

            playerController.Deselect(gameObject);
            
            Destroy(gameObject);
        }
        else if(isSelected)
        {
            displayInfo.EditUnitInfo(currentHealth, maxHealth);
        }
    }

    public void CollectResources(Resource resource)
    {
        StopAllCoroutines();
        StartCoroutine(ProcessCollectResource(resource));
    }

    public IEnumerator ProcessCollectResource(Resource resource)
    {
        while (resource.Resources>0)
        {
            float distance = Vector3.Distance(resource.transform.position, transform.position);
            if (distance > attackRange)
            {
                Debug.Log("Moving");
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

    }

}
