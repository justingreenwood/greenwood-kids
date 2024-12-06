using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] public GameObject buildTimeVisual;



    [SerializeField] float buildingTimeLeft = 0;//needs to be viewable on screen
    [SerializeField] float timeTakenToBuild = 20f;
    [SerializeField] public float width = 8;

    [SerializeField] public bool isBuilt = false;

    [SerializeField] public List<Technology> researchableTechnology = new List<Technology>();

    public List<GameObject> unitQueue = new List<GameObject>();

    bool isCurrentlyBuilding = false;
    public bool IsCurrentlyBuilding { get { return isCurrentlyBuilding; } }

    [SerializeField] public TextMeshPro buildTimeVisualTMP;
    public BuildingGrid buildGrid;
    public Vector2Int vTwoPosition;
    GuyMovement guyMovement;
    public GuyMovement GMovement { get { return guyMovement; } }

    PlayerController playerController;
    ComputerController computerController;
    GameObject player;
    ResourceBank bank;

    private void Awake()
    {
        buildGrid = FindObjectOfType<BuildingGrid>();
        guyMovement = GetComponent<GuyMovement>();
        guyMovement.isABuilding = true;
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        player = playerController.gameObject;
        if (CompareTag(player.tag))
        {
            transform.parent = player.transform;
            bank = player.GetComponent<ResourceBank>();
        }
        else if(tag != null)
        {
            transform.parent = FindObjectOfType<ComputerController>().transform;
            computerController = GetComponentInParent<ComputerController>();
            bank = computerController.GetComponent<ResourceBank>();


        }

        int width = Mathf.RoundToInt(gameObject.transform.localScale.x);

        if (width == 4)
        {
            foreach (GridSquares i in buildGrid.gridSquares)
            {
                vTwoPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x) - width / 2, Mathf.RoundToInt(transform.position.z) - width / 2);
                if (i.position == vTwoPosition)
                {
                    i.isClaimed = true;
                    buildGrid.gridSqrsDict[vTwoPosition] = true;

                    break;
                }
            }
        }
        else
        {
            vTwoPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x) - width / 2, Mathf.RoundToInt(transform.position.z) - width / 2);
            foreach (GridSquares i in buildGrid.gridSquares)
            {

                if (i.position == vTwoPosition)
                {
                    i.isClaimed = true;
                    buildGrid.gridSqrsDict[vTwoPosition] = true;

                }
                else if (i.position.x == vTwoPosition.x + 4 && i.position.y == vTwoPosition.y)
                {
                    i.isClaimed = true;
                    buildGrid.gridSqrsDict[vTwoPosition] = true;
                }
                else if (i.position.x == vTwoPosition.x + 4 && i.position.y == vTwoPosition.y + 4)
                {
                    i.isClaimed = true;
                    buildGrid.gridSqrsDict[vTwoPosition] = true;
                }
                else if (i.position.x == vTwoPosition.x && i.position.y == vTwoPosition.y + 4)
                {
                    i.isClaimed = true;
                    buildGrid.gridSqrsDict[vTwoPosition] = true;
                }
            }
        }

        buildTimeVisualTMP.text = "";
    }

    private void Update()
    {
        if (isCurrentlyBuilding == false && isBuilt)
        {
            if (unitQueue.Count > 0)
            {
                BuildUnit(unitQueue[0]);
            }
        }
    }

    public void RemoveUnitFromQueue(int i)
    {
        if (i == 0)
        {
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
    public bool BuildUnit(GameObject chosenUnit)
    {
        GuyMovement chosenGuyM = chosenUnit.GetComponent<GuyMovement>();
        bool willBuild = bank.HasEnoughResource(chosenGuyM.UnitWoodCost, chosenGuyM.UnitGemCost, chosenGuyM.UnitFoodCost);
        if (!willBuild)
        {
            Debug.Log("Not enough Resources");

            return false;
        }
        bank.RemoveResource(chosenGuyM.UnitWoodCost, chosenGuyM.UnitGemCost, chosenGuyM.UnitFoodCost);
        bank.BorrowedResources(chosenGuyM.UnitWoodCost, chosenGuyM.UnitGemCost, chosenGuyM.UnitFoodCost);
        if (CompareTag(player.tag))
            playerController.unitsAlive++;
        else
        {

        }
        StartCoroutine(ProcessBuildUnit(chosenUnit));
        return true;
    }

    IEnumerator ProcessBuildUnit(GameObject chosenUnit)
    {
        guyMovement.currentAction = UnitActions.Build;
        isCurrentlyBuilding = true;
        float x = 0;
        float buildSpeed = timeTakenToBuild / 20;
        while (x <= timeTakenToBuild)
        {

            yield return new WaitForSeconds(buildSpeed);
            x += buildSpeed;
            buildingTimeLeft = timeTakenToBuild - x;
            buildTimeVisualTMP.text += "N";
        }
        buildTimeVisualTMP.text = "";
        Vector3 pos = transform.position;
        pos.x = transform.position.x + 1 / transform.localScale.x;
        pos.x += 2;
        guyMovement.Build(chosenUnit, guyMovement.buildingMaterial, pos);
        bank.ResetBorrowedResources();
        unitQueue.Remove(chosenUnit);

        playerController.EditDisplay();
        isCurrentlyBuilding = false;
        guyMovement.currentAction = UnitActions.Nothing;

    }

    public void Research(Technology t)
    {
        Debug.Log("RESEARCHING");
        guyMovement.currentAction = UnitActions.Research;
        StartCoroutine(Researching(t));
    }

    IEnumerator Researching(Technology t)
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);

        }
        if (playerController != null)
        {
            playerController.Research(t);
        }
        else
        {

        }
    }

}
