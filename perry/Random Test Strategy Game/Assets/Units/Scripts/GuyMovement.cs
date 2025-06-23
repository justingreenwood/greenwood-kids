using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using TMPro;
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

    [SerializeField] public float maxHealth = 50;

    [SerializeField] public float currentHealth = 0;
    [SerializeField] int healthIncreaseIncrement = 2;
    public int healthIncInc { get { return healthIncreaseIncrement; } }
    [SerializeField] public int armor = 0;
    public int bonusArmor = 0;
    [SerializeField] float attackRange = 10;
    [SerializeField] public float attackDamage = 5;
    public float bonusAttackDamage = 0;
    [SerializeField] public float attackSpeed = 0.75f;
    public float finalAttackSpeed = 0;


    [SerializeField] public float moveDelay = 0.5f;
    [SerializeField] float sightRange = 20f;
    public float SightRange { get { return sightRange; } }
    [SerializeField] public UnitType unitType;

    [SerializeField] public TechType weaponType;
    [SerializeField] public TechType armorType;
    [SerializeField] public TechType healthType;
    [SerializeField] public TechType rangeType;



    [SerializeField] public bool isMovable = true;
    [SerializeField] public bool targetsNearestEnemy = false;
    [SerializeField] public bool canAttackFlying = false;
    [SerializeField] public bool isFlying = false;
    public bool isABuilding = false;
    [SerializeField] public bool isABuilder = false;
    public bool isSelected = false;
    public bool isAttacking = false;
    [SerializeField] public Sprite unitImage;

    [SerializeField] public bool canProduceUnits = true;

    [SerializeField] public Material buildingMaterial;
    [SerializeField] public Renderer coloredPart;

    [SerializeField] List<UnitType> unitTypes;
    [SerializeField] List<GameObject> unitGameObjects;
    [SerializeField] public List<UnitType> requiredStructures = null;

    [SerializeField] public AudioClip[] isSelectedAudio;
    [SerializeField] public AudioClip[] IncapableAudio;
    [SerializeField] public AudioClip[] ActionAudio;

   
    public List<GameObject> UnitGameObjects { get { return unitGameObjects; } }
    public List<UnitType> UnitTypes { get { return unitTypes; } }
    

    [SerializeField] int unitWoodCost = 0;
    [SerializeField] int unitGemCost = 0;
    [SerializeField] int unitFoodCost = 0;
    [SerializeField] public int unitSize = 1;

    [SerializeField] public int timeTakenToBuild = 20;
    public int UnitWoodCost { get { return unitWoodCost; } }
    public int UnitFoodCost { get { return unitFoodCost; } }
    public int UnitGemCost { get { return unitGemCost; } }
    public NavMeshAgent agent;
    public PlayerController playerController;
    public ComputerController computerController;
    GameObject player;
    ResourceBank bank;

    public List<GuyMovement> targeters = new List<GuyMovement>();

    public GameObject target = null;

    public bool isCurrentlyBuilding = false;

    public bool isCollectingResources = false;
    bool moveActionOn = false;

    public UnitActions currentAction = UnitActions.Nothing;
    public DisplayInformationToScreen displayInfo;

    public Vector3 destination = Vector3.zero;

    Building buildingActions;
    BuilderActions builderActions;
    public HPNonUIVisAid hPNonUIVisAid;

    public Building BuildingActions { get { return buildingActions; } }
    public BuilderActions BuilderActions { get { return builderActions; } }
    public BuildingGrid buildGrid;

    public int borrowedFood = 0;
    public int borrowedWood = 0;
    public int borrowedGems = 0;


    Information techInfo;
    private void Awake()
    {
        finalAttackSpeed = attackSpeed;
    }

    void Start()
    {
        if (isABuilding)
        {
            buildingActions = GetComponent<Building>();
        }
        else if(isABuilder)
        {
            builderActions = GetComponent<BuilderActions>();
        }

        hPNonUIVisAid = GetComponentInChildren<HPNonUIVisAid>();
        hPNonUIVisAid.EditTMP(currentHealth, maxHealth);
        hPNonUIVisAid.gameObject.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        playerController = FindObjectOfType<PlayerController>();

        player = playerController.gameObject;

        if (CompareTag(player.tag))
        {
            transform.parent = player.transform;
            techInfo = playerController.TechInfo;
            bank = player.GetComponent<ResourceBank>();


        }
        else
        {
            transform.parent = FindObjectOfType<ComputerController>().transform;
            computerController = GetComponentInParent<ComputerController>();
            bank = computerController.GetComponent<ResourceBank>();


        }
        displayInfo = playerController.DisplayInfo();
        buildGrid = FindObjectOfType<BuildingGrid>();
    }

    private void Update()
    {
        if (targetsNearestEnemy && target == null && !moveActionOn)
        {
            SearchForTarget();
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
            else if(g.isFlying && !canAttackFlying)
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
        {
            if (isFlying)
            {
                Vector3 targetPos = groundLocation.Value;
                targetPos.y = 10;
                agent.SetDestination(targetPos);
            }
            else
            {
                agent.SetDestination(groundLocation.Value);
            }
            
        }           
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
        StopActivities();
        enemy.targeters.Add(this);
        StartCoroutine(ProcessAttack(enemy));
    }

    IEnumerator ProcessAttack(GuyMovement enemy)
    {
        float finalAttackDamage;
        while (enemy.currentHealth > 0)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            distance = distance - enemy.unitSize / 2;
            if (distance > attackRange)
            {

                if (isABuilding)
                {
                    target = null;
                    break;
                }

                currentAction = UnitActions.Move;
                //Debug.Log("Moving");
                Vector3 destination = Vector3.MoveTowards(transform.position, enemy.transform.position, distance - attackRange + 1);
                Move(destination);
                yield return new WaitForSeconds(moveDelay);
            }
            else
            {
                yield return new WaitForSeconds(finalAttackSpeed);
                isAttacking = true;
                finalAttackDamage = attackDamage + bonusAttackDamage;
                enemy.TakeDamage(finalAttackDamage);
            }


        }
        isAttacking = false;
    }

    public void EnterTower(TowerActions tower)
    {
        StopAllCoroutines();
        Move(tower.transform.position);
        StartCoroutine(EnteringTower(tower));
    }

    IEnumerator EnteringTower(TowerActions tower)
    {
        float width = tower.GetComponent<Building>().width + 1;
        float distance = Vector3.Distance(tower.transform.position, transform.position);
        while (distance > width)
        {
            distance = Vector3.Distance(tower.transform.position, transform.position);

            yield return new WaitForSeconds(moveDelay);
        }
        target = null;
        RemoveTargeters();
        tower.AddUnit(gameObject);
    }

    public void SetNewUnitDestination(Vector3 position)
    {
        destination = position;
    }

    public void Build(GameObject objectPrefab, Material material, Vector3 groundPos)
    {

        var rotation = Quaternion.Euler(0, 0, 0);
        //groundPos.y += objectPrefab.transform.localScale.y / 2;
        groundPos.y = 0.1f;
        GameObject newGameObject = Instantiate(objectPrefab, groundPos, rotation);
        newGameObject.tag = tag;
        
        GuyMovement guyMovement = newGameObject.GetComponent<GuyMovement>();
        guyMovement.coloredPart.material = buildingMaterial;

        if (techInfo != null)
        {
            int healthies = 0;
            int armories = 0;
            int weaponies = 0;
            foreach (ITech t in techInfo.Technologies)
            {
                if (t.techType == guyMovement.healthType)
                {
                    healthies++;
                }
                else if (t.techType == guyMovement.weaponType)
                {
                    weaponies++;
                }
                else if (t.techType == guyMovement.rangeType)
                {
                    guyMovement.attackRange += 3;
                }               
                else if (t.techType == guyMovement.armorType)
                {
                    armories++;
                }
                else if (guyMovement.unitType == UnitType.Knight)
                {
                    if (t.techType == TechType.Armor)
                    {
                        armories++;
                    }
                }
            }

            guyMovement.bonusAttackDamage += weaponies * 2;
            guyMovement.armor += armories * 3;
            var healthAddition = healthies * guyMovement.maxHealth * 0.2f;
            guyMovement.maxHealth += healthAddition;
            if (!guyMovement.isABuilding)
            {
                guyMovement.currentHealth += healthAddition;
            }
        }


        guyMovement.buildingMaterial = material;
        if (computerController != null)
        {
            computerController.uLib.AddUnit(newGameObject.GetComponent<GuyMovement>());
        }
        else if (playerController != null)
        {
            playerController.unitLibrary.AddUnit(newGameObject.GetComponent<GuyMovement>());
        }

        if (destination != Vector3.zero)
        {
            newGameObject.GetComponent<Building>().isBuilt = true;
            newGameObject.GetComponent<GuyMovement>().Move(destination);
        }


    }

    public void TakeDamage(float damage)
    {
        float finalDamage = damage - armor - bonusArmor;
        if (finalDamage < 1)
        {
            currentHealth -= 1;
        }
        else
        {
            currentHealth -= finalDamage;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        else if (isSelected)
        {
            displayInfo.EditUnitInfo(currentHealth, maxHealth);
        }
        hPNonUIVisAid.EditTMP(currentHealth, maxHealth);
    }

    public void Die()
    {
        if (isSelected)
        {
            playerController.Deselect(gameObject);
        }
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
            playerController.unitLibrary.RemoveUnit(this);
        }
        else if (tag != null)
        {
            computerController.uLib.RemoveUnit(this);
        }
        
        if(isABuilder && currentAction == UnitActions.Build)
        {
            if (builderActions.newBuilding == null)
            {
                Debug.Log("Problem!!!!!!!!!");

            }
            else
            {

                Building buildingActions = builderActions.newBuilding.GetComponent<Building>();
                buildingActions.builder = null;
                buildingActions.hasBuilder = false;
                if(computerController!= null)
                {
                    computerController.NeedBuilder(buildingActions);
                }

            }
            
        }

        if (isABuilding)
        {
            Building buildingActions = GetComponent<Building>();
            if (buildingActions.raisesUnitLimit)
            {
                bank.LowerUnitLimit();
            }

            foreach (var i in buildGrid.gridSquares)
            {
                if (i.position == buildingActions.vTwoPosition)
                {
                    i.isClaimed = false;
                }
            }
            if (TryGetComponent(out TowerActions tower))
            {
                foreach (var unit in tower.housedUnits)
                {
                    unit.SetActive(true);
                }
            }
            else if (TryGetComponent(out FarmlandActions farmland))
            {
                farmland.ClearFarmers();
            }
            if(currentAction == UnitActions.Research)
            {
                buildingActions.StopResearch();
            }

            if (buildingActions.hasBuilder)
            {
                buildingActions.builder.StopActivities();
            }

        }
        RemoveTargeters();
        Destroy(gameObject);
    }

    public void RemoveTargeters()
    {
        foreach (var targeter in targeters)
        {
            if (targeter != null)
            {
                targeter.target = null;
                targeter.StopAllCoroutines();
            }
        }
    }

    public void StopActivities()
    {
        currentAction = UnitActions.Nothing;
        isCollectingResources = false;
        isCurrentlyBuilding = false;
        if (unitType != UnitType.Castle)
        {
            isAttacking = false;
            StopAllCoroutines();
        }
    }

    void BorrowedResources(int food, int wood, int gems)
    {
        borrowedWood += wood;
        borrowedGems += gems;
        borrowedFood += food;
    }
    public void BorrowResources(int food, int wood, int gems)
    {
        BorrowedResources(food, wood, gems);
        bank.RemoveResource(food, wood, gems);
    }

    public void ResetBorrowedResources()
    {
        borrowedWood = 0;
        borrowedGems = 0;
        borrowedFood = 0;
    }
    public void ReturnBorrowedResources()
    {
        bank.AddResources(borrowedFood, borrowedWood, borrowedGems);
        ResetBorrowedResources();
    }
}
