using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] public GameObject buildingPreview;
    [SerializeField] public GameObject buildTimeVisGO;
    [SerializeField] public GameObject buildingUpgrade;
    [SerializeField] public UnitType buildingUpgradeType;
    [SerializeField] float buildingTimeLeft = 0;//needs to be viewable on screen
    [SerializeField] public int width = 8;

    [SerializeField] public bool isBuilt = false;

    [SerializeField] public bool raisesUnitLimit = false;

    [SerializeField] public List<ITech> researchableTechnology = new List<ITech>();

    Information techInfo;
    public List<GameObject> unitQueue = new List<GameObject>();

    bool isCurrentlyBuilding = false;
    public bool isUpgradeable = false;
    public bool IsCurrentlyBuilding { get { return isCurrentlyBuilding; } }
    public bool hasBuilder = false;
    public GuyMovement builder = null;

    [SerializeField] public TextMeshPro buildTimeVisTMP;
    public BuildingGrid buildGrid;
    public Vector2Int vTwoPosition;
    GuyMovement guyMovement;
    public GuyMovement GMovement { get { return guyMovement; } }

    PlayerController playerController;
    ComputerController computerController;
    GameObject player;
    ResourceBank bank;

    TechType currentTech = TechType.Nothing;
    public TechType CTech { get { return currentTech; } }
    private void Awake()
    {
        buildGrid = FindObjectOfType<BuildingGrid>();
        guyMovement = GetComponent<GuyMovement>();
        guyMovement.isABuilding = true;
        buildTimeVisTMP = buildTimeVisGO.GetComponentInChildren<TextMeshPro>();
        if (buildingUpgrade != null)
        {
            isUpgradeable = true;
        }
    }

    private void Start()
    {

        playerController = FindObjectOfType<PlayerController>();

        player = playerController.gameObject;
        if (CompareTag(player.tag))
        {
            techInfo = playerController.TechInfo;
            transform.parent = player.transform;
            bank = player.GetComponent<ResourceBank>();
        }
        else if(tag != null)
        {
            transform.parent = FindObjectOfType<ComputerController>().transform;
            computerController = GetComponentInParent<ComputerController>();
            bank = computerController.GetComponent<ResourceBank>();
            techInfo = computerController.techInfo;

        }

        //int width = Mathf.RoundToInt(gameObject.transform.localScale.x);
        vTwoPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x) - width / 2, Mathf.RoundToInt(transform.position.z) - width / 2);
        if (width == 4)
        {
            buildGrid.gridSqrsDict[vTwoPosition] = true;
        }
        else
        {
            Vector2Int v2PosTL = new Vector2Int(vTwoPosition.x,vTwoPosition.y+4);
            Vector2Int v2PosTR = new Vector2Int(vTwoPosition.x + 4, vTwoPosition.y + 4);
            Vector2Int v2PosBL = new Vector2Int(vTwoPosition.x + 4, vTwoPosition.y);
            buildGrid.gridSqrsDict[vTwoPosition] = true;
            buildGrid.gridSqrsDict[v2PosTL] = true;
            buildGrid.gridSqrsDict[v2PosBL] = true;
            buildGrid.gridSqrsDict[v2PosTR] = true;
            //Debug.Log($"These have been claimed: {vTwoPosition} {v2PosTL} {v2PosBL} {v2PosTR}");
        }

        buildTimeVisTMP.text = "";
        buildTimeVisGO.SetActive(false);
    }

    private void Update()
    {
        if (isCurrentlyBuilding == false && isBuilt)
        {
            
            if (unitQueue.Count > 0)
            {
                //Debug.Log("You got here! yippee");
                BuildUnit(unitQueue[0], false);
            }
        }
    }

    public void RemoveUnitFromQueue(int i)
    {
        if (i == 0)
        {
            playerController.unitsAlive -= unitQueue[i].GetComponent<GuyMovement>().unitSize;
            StopAllActivities();
            guyMovement.ReturnBorrowedResources();
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
    public bool BuildUnit(GameObject chosenUnit, bool isUpgrade)
    {
        GuyMovement chosenGuyM = chosenUnit.GetComponent<GuyMovement>();
        bool willBuild = bank.HasEnoughResource(chosenGuyM.UnitFoodCost, chosenGuyM.UnitWoodCost, chosenGuyM.UnitGemCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources!");

            return false;
        }
        if(computerController == null)
        {
            if (bank.UnitLimit <= guyMovement.playerController.unitLibrary.Units().Count)
            {
                Debug.Log("Need more houses!");

                return false;
            }
        }
        
        guyMovement.BorrowResources(chosenGuyM.UnitFoodCost,chosenGuyM.UnitWoodCost, chosenGuyM.UnitGemCost);
        if (CompareTag(player.tag))
        {
            playerController.unitsAlive++;
        }

        StartCoroutine(ProcessBuildUnit(chosenUnit, isUpgrade));
        return true;
    }

    IEnumerator ProcessBuildUnit(GameObject chosenUnit, bool isUpgrade)
    {
        if (computerController == null&&guyMovement.isSelected)
        {
            buildTimeVisGO.SetActive(true);
        }
            
        if (!isUpgrade)
        {
            guyMovement.currentAction = UnitActions.Build;
        }
        isCurrentlyBuilding = true;
        float x = 0;
        var timeTakenToBuild = chosenUnit.GetComponent<GuyMovement>().timeTakenToBuild;
        float buildTimeIncrement = timeTakenToBuild / 20;
        while (x <= 20)
        {

            yield return new WaitForSeconds(buildTimeIncrement);
            x += 1;
            buildingTimeLeft = timeTakenToBuild - x;
            if (computerController == null)
                buildTimeVisTMP.text += "N";
        }
        if (computerController == null)
        {
            buildTimeVisTMP.text = "";
            buildTimeVisGO.SetActive(false);
        }
        Vector3 pos = transform.position;
        pos.x = transform.position.x + 1 / transform.localScale.x;
        pos.x += 2;
        if(isUpgrade)
        {
            pos.x -= 3;
        }
        guyMovement.Build(chosenUnit, guyMovement.buildingMaterial, pos);
        
        if(computerController != null)
        {
            computerController.mayNeedToAttack = true;
        }
        guyMovement.ResetBorrowedResources();
        unitQueue.Remove(chosenUnit);
        isCurrentlyBuilding = false;
        guyMovement.currentAction = UnitActions.Nothing;
        if (computerController == null)
        {
            playerController.EditDisplay();
        }
        
        if (isUpgrade)
        {
            guyMovement.Die();
        }
        
    }

    public bool Research(ITech t)
    {
        Debug.Log(techInfo.name+ " Bologna");
        string failedRequirements = techInfo.CheckRequirements(t);
        if (failedRequirements != null)
        {
            Debug.Log("Requires:" + failedRequirements);

            return false;
        }
        bool willBuild = bank.HasEnoughResource(t.foodCost,t.woodCost,t.gemCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources");

            return false;
        }
        guyMovement.BorrowResources(t.foodCost, t.woodCost, t.gemCost);
        Debug.Log("RESEARCHING");
        guyMovement.currentAction = UnitActions.Research;
        StartCoroutine(Researching(t));
        return true;
    }

    IEnumerator Researching(ITech t)
    {     

        currentTech = t.techType;
        Debug.Log(t.techType);
        techInfo.Research(t.techType);
        if (computerController == null)
        {
            buildTimeVisGO.SetActive(true);
        }
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(1f);
            if (computerController == null)
                buildTimeVisTMP.text += "N";

        }
        if (computerController == null)
            buildTimeVisGO.SetActive(false);
        if (techInfo != null)
        {
            researchableTechnology.Remove(t);
            guyMovement.ResetBorrowedResources();
            techInfo.ResearchCompletion(t.techType);
            if(computerController == null) 
            {
                playerController.EditDisplay();
            }
        }
        buildTimeVisTMP.text = "";
        guyMovement.currentAction = UnitActions.Nothing;
        
    }
    public void StopResearch()
    {
        StopAllCoroutines();
        guyMovement.currentAction = UnitActions.Nothing;
        buildTimeVisGO.SetActive(false);
        techInfo.StopResearch(currentTech, guyMovement.unitType);
        currentTech = TechType.Nothing;
        buildTimeVisTMP.text = "";
        guyMovement.ReturnBorrowedResources();
    }

    public bool UpgradeBuilding()
    {
        if (guyMovement.currentAction == UnitActions.Nothing)
        {
            guyMovement.currentAction = UnitActions.Upgrading;
            BuildUnit(buildingUpgrade, true);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StopAllActivities()
    {
        StopAllCoroutines();
        guyMovement.StopActivities();
        isCurrentlyBuilding = false;
        buildTimeVisGO.SetActive(false);
        buildTimeVisTMP.text = "";
    }

    public void CancelUpgrade()
    {
        StopAllActivities();
        guyMovement.ReturnBorrowedResources();
    }

}
