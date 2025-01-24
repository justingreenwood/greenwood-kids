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
    public float bonusHealth = 0;
    [SerializeField] int healthIncreaseIncrement = 2;
    public int healthII { get { return healthIncreaseIncrement; } }
    [SerializeField] public int armor = 0;
    public int bonusArmor = 0;
    [SerializeField] float attackRange = 10;
    [SerializeField] public float attackDamage = 5;
    public float bonusAttackDamage = 0;
    [SerializeField] public float attackSpeed = 0.75f;
    public float finalAttackSpeed = 0;


    [SerializeField] public float moveDelay = 0.5f;
    [SerializeField] float sightRange = 20f;
    [SerializeField] public UnitType unitType;

    [SerializeField] public bool isMovable = true;
    [SerializeField] public bool targetsNearestEnemy = false;
    public bool isABuilding = false;
    [SerializeField] public bool isABuilder = false;
    public bool isSelected = false;
    public bool isAttacking = false;
    [SerializeField] public Sprite unitImage;

    [SerializeField] public bool canProduceUnits = true;

    [SerializeField] public Material buildingMaterial;


    [SerializeField] bool hasUnitWorth = false;
    public bool HasUnitWorth { get { return hasUnitWorth; } }

    [SerializeField] List<UnitType> unitTypes;
    [SerializeField] List<GameObject> unitGameObjects;


    [SerializeField] public AudioClip[] isSelectedAudio;
    [SerializeField] public AudioClip[] IncapableAudio;
    [SerializeField] public AudioClip[] ActionAudio;

    //[SerializeField] public Dictionary<UnitType, GameObject> unitTypes = new Dictionary<UnitType, GameObject>();
    public List<GameObject> UnitGameObjects { get { return unitGameObjects; } }
    public List<UnitType> UnitTypes { get { return unitTypes; } }
    

    [SerializeField] int unitWoodCost = 0;
    [SerializeField] int unitGemCost = 0;
    [SerializeField] int unitFoodCost = 0;
    [SerializeField] public int unitSize = 1;
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
    Builder builderActions;
    public HPNonUIVisAid hPNonUIVisAid;

    public Building BuildingActions { get { return buildingActions; } }
    public Builder BuilderActions { get { return builderActions; } }
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
            builderActions = GetComponent<Builder>();
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

    public void EnterTower(Tower tower)
    {
        StopAllCoroutines();
        Move(tower.transform.position);
        StartCoroutine(EnteringTower(tower));
    }

    IEnumerator EnteringTower(Tower tower)
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
        groundPos.y += objectPrefab.transform.localScale.y / 2;
        GameObject newGameObject = Instantiate(objectPrefab, groundPos, rotation);
        newGameObject.tag = tag;
        newGameObject.GetComponentInChildren<Renderer>().material = buildingMaterial;
        GuyMovement guyMovement = newGameObject.GetComponent<GuyMovement>();

        if (techInfo != null)
        {
            int healthies = 0;
            int armories = 0;
            int weaponies = 0;
            foreach (ITech t in techInfo.Technologies)
            {
                if(t.techType == TechType.Health)
                {
                    healthies++;
                }
                else if (t.techType == TechType.Weapon)
                {
                    healthies++;
                }
                else if (t.techType == TechType.Armor)
                {
                    healthies++;
                }
                else
                {
                    Debug.Log("There is a problem with Technology.");
                }
            }
            guyMovement.bonusAttackDamage = +weaponies * 2;
            guyMovement.armor += armories * 3;
            guyMovement.maxHealth += healthies * 5;
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

    private void Die()
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
            playerController.unitLibrary.RemoveUnit(this);
        }
        else if (tag != null)
        {
            computerController.uLib.RemoveUnit(this);
        }
        if (hasUnitWorth)
        {
            bank.LowerUnitLimit();
        }

        if (isABuilding)
        {
            Building buildingActions = GetComponent<Building>();
            foreach (var i in buildGrid.gridSquares)
            {
                if (i.position == buildingActions.vTwoPosition)
                {
                    i.isClaimed = false;
                }
            }
            if (TryGetComponent(out Tower tower))
            {
                foreach (var unit in tower.housedUnits)
                {
                    unit.SetActive(true);
                }
            }
            else if (TryGetComponent(out Farmland farmland))
            {
                farmland.ClearFarmers();
            }
            if(currentAction == UnitActions.Research)
            {
                buildingActions.StopResearch();
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
