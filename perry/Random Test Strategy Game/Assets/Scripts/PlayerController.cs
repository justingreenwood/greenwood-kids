using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;
using UnityEngine.AI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Linq;
using System.Linq.Expressions;
using TMPro.Examples;

public class PlayerController : MonoBehaviour
{

    Camera cam;
    NavMeshAgent agent;
    public LayerMask groundLayerMask;
    public LayerMask unitLayerMask;
    public LayerMask resourceMask;

    bool buildModeOn = false;
    bool buildButtonPressed = false;
    bool skipSelection = false;
    public int unitsAlive = 0;
    public int unitsBeingBuilt = 0;

    [SerializeField] GameObject largeBuildingPreview;
    [SerializeField] GameObject smallBuildingPreview;



    [SerializeField] UnityEngine.UI.Button[] unitUIVisualButtons;

    DisplayInformationToScreen displayInfo;
    public DisplayInformationToScreen DisplayInfo() { return displayInfo; }

    GameObject currentBuildingPreview;
    ResourceBank resourceBank;
    public BuildingGrid buildGrid;

    List<GameObject> selectedUnits = new List<GameObject>();
    string team = "Yellow Team";
    [SerializeField] UnityEngine.UI.Button[] unitActionButtons;
    [SerializeField] UnityEngine.UI.Button[] buildQueueButtons;
    [SerializeField] UnityEngine.UI.Button[] housedUnitButtons;

    AudioSource audioSource;
    public UnitLibrary unitLibrary;
    Information techInfo;
    public Information TechInfo { get { return techInfo; } }
    void Awake()
    {
        GameObject[] buildingsAndUnits = GameObject.FindGameObjectsWithTag(team);
        foreach (GameObject thing in buildingsAndUnits)
        {
            if (thing.GetComponent<GuyMovement>()) 
            {
                var guyMovement = thing.GetComponent<GuyMovement>();
                if (!guyMovement.isABuilding)
                {
                    unitsAlive++;
                }
            }
        }

        displayInfo = GetComponent<DisplayInformationToScreen>();
        techInfo = GetComponent<Information>();
        buildGrid = FindObjectOfType<BuildingGrid>();
    }

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        resourceBank  = GetComponent<ResourceBank>();
        currentBuildingPreview = largeBuildingPreview;

        audioSource = GetComponent<AudioSource>();
        unitLibrary = GetComponent<UnitLibrary>();
        EditDisplay();
    }

    void Update()
    {
        var leftButtonPressed = Input.GetMouseButtonUp(0);
        var rightButtonPressed = Input.GetMouseButtonUp(1);
        if (leftButtonPressed || rightButtonPressed)
        {
            Vector3? groundLocation = null;
            GameObject objectHit = null;
            RaycastHit unitHit, groundHit, resourceHit;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out unitHit, Mathf.Infinity, unitLayerMask))
                objectHit = unitHit.collider.gameObject;
            else if(Physics.Raycast(ray, out resourceHit, Mathf.Infinity, resourceMask))
                objectHit = resourceHit.collider.gameObject;
            else if (Physics.Raycast(ray, out groundHit, Mathf.Infinity, groundLayerMask))
                groundLocation = groundHit.point;

            if (leftButtonPressed)
            {
                UnitSelection(groundLocation, objectHit);
            }
            else if (rightButtonPressed && selectedUnits.Count > 0)
            {
                var canBuild = true;
                if (selectedUnits.Count > 1)
                {
                    canBuild = false;
                }

                UnitAction(groundLocation, objectHit, canBuild);
            }
        }       

    }

    public void BuildButtonPressed(GameObject chosenBuildOption)
    {
        buildButtonPressed = true;
        if (selectedUnits.Count == 1)
        {
            foreach (var unit in selectedUnits)
            {
                
                var unitControls = unit.GetComponent<GuyMovement>();
                if (unitControls.isABuilding)
                {
                    Building buildingAction = unit.GetComponent<Building>();
                    if (unitControls.canProduceUnits)
                    {

                        buildingAction.AddToQueue(chosenBuildOption);
                        EditDisplay();
                        buildModeOn = false;
                    }
                }
                else if (!unitControls.isCurrentlyBuilding && unitControls.isABuilder)
                {
                    SetBuildMode(true, chosenBuildOption);
                    unitControls.BuilderActions.basicBuilding = chosenBuildOption;

                }
            }
        }

    }

    void UnitAction(Vector3? groundLocation, GameObject objectHit, bool canBuild)
    {
        bool actionDone = false;
        bool canDoActionSound = true;
        GameObject selectedUnit = selectedUnits[0];
        if (selectedUnit.GetComponent<GuyMovement>().isABuilding) { canDoActionSound = false; }
        else 
        { 
            foreach (var unit in selectedUnits)
            {
                var unitControls = unit.GetComponent<GuyMovement>();
                if (!unitControls.isCurrentlyBuilding)
                {
                    unitControls.StopAllCoroutines();
                    unitControls.target = null;
                    if (unitControls.isABuilder && !unitControls.isCurrentlyBuilding)
                    {
                        unitControls.currentAction = UnitActions.Nothing;
                        unitControls.BuilderActions.StopAllCoroutines();
                    }
                    if (groundLocation.HasValue)
                    {
                        actionDone = true;
                        if (buildModeOn)
                        {
                            canDoActionSound = false;
                            Building(canBuild, unitControls);
                        }
                        else
                        {
                            unitControls.MoveActionWait();
                            unitControls.Move(groundLocation.Value);
                        }
                    }

                    if (objectHit != null && objectHit != unit)
                    {
                        

                        if (buildModeOn)
                        {
                            SetBuildMode(false);
                            return;
                        }
                        if (objectHit.TryGetComponent(out Resource resource))
                        {
                            if (unitControls.isABuilder)
                            {
                                actionDone = true;
                                Debug.Log("I Collect Resource");
                                unitControls.BuilderActions.CollectResources(resource);
                            }
                        }
                        else if (CompareTag(objectHit.tag))
                        {
                            GuyMovement objectGuyMovement = objectHit.GetComponent<GuyMovement>();
                            if (unitControls.isABuilder && objectGuyMovement.currentHealth< objectGuyMovement.maxHealth)
                            {
                                actionDone = true;
                                Repairing(unitControls, objectGuyMovement);
                            }
                            else if (objectHit.TryGetComponent(out Tower tower))
                            {
                                actionDone = true;
                                Debug.Log("Lets GO!!!");
                                unitControls.EnterTower(tower);
                            }
                        }
                        else
                        {
                            GuyMovement targetControls = objectHit.GetComponent<GuyMovement>();
                            if (targetControls.isFlying && !unitControls.canAttackFlying)
                            {
                                Debug.Log("I cannot attack that.");
                                AudioClip[] unitActionAudio = selectedUnit.GetComponent<GuyMovement>().IncapableAudio;
                                int i = Random.Range(0, unitActionAudio.Length);
                                PlaySound(unitActionAudio[i]);
                            }
                            else
                            {

                                actionDone = true;
                                unitControls.target = objectHit;
                                unitControls.Attack(objectHit.GetComponent<GuyMovement>());
                            }
                            
                        }
                    }
                }
            }
            if (actionDone && canDoActionSound)
            {
                AudioClip[] unitActionAudio = selectedUnit.GetComponent<GuyMovement>().ActionAudio; 
                int i = Random.Range(0, unitActionAudio.Length);
                PlaySound(unitActionAudio[i]);
            }
        }
    }

    void Repairing(GuyMovement unitControls, GuyMovement target)
    {
        if (target.GetComponent<Building>().isBuilt)
        {

            if (resourceBank.Wood >= 1)
            {
                unitControls.BuilderActions.Repair(target);
                Debug.Log("Repairing");
            }
            else
            {
                Debug.Log("Not enough wood!");
            }
        }
    }

    void Building(bool canBuild, GuyMovement unitControls)
    {
        Vector3 previewPos = currentBuildingPreview.transform.position;
        BuildingPreview buildingPreviewScript = currentBuildingPreview.GetComponent<BuildingPreview>();
        if (!buildingPreviewScript.BlockConstruction)
        {
            if (canBuild)
            {
                Debug.Log("I am building.");
                if (unitControls.BuilderActions.BuildBuilding(previewPos))
                {
                    int i = Random.Range(0, unitControls.ActionAudio.Length);
                    PlaySound(unitControls.ActionAudio[i]);
                }
                else
                {
                    int i = Random.Range(0, unitControls.IncapableAudio.Length);
                    PlaySound(unitControls.IncapableAudio[i]);
                }
            }
            SetBuildMode(false);
        }
        else
        {
            Debug.Log("Can't build there.");
            int i = Random.Range(0, unitControls.IncapableAudio.Length);
            PlaySound(unitControls.IncapableAudio[i]);
        }

       
    }

    public void SetBuildMode(bool isBuilding)
    {
        
        buildModeOn = isBuilding;
        Debug.Log(buildModeOn);

        currentBuildingPreview.SetActive(isBuilding);

    }
    public void SetBuildMode(bool isBuilding, GameObject building)
    {

        buildModeOn = isBuilding;
        Debug.Log(buildModeOn);
        currentBuildingPreview.SetActive(false);
        if (building.GetComponent<Building>().width == 4)
        {
            currentBuildingPreview = smallBuildingPreview;
        }
        else
        {
            currentBuildingPreview = largeBuildingPreview;
        }
        
        currentBuildingPreview.SetActive(isBuilding);

    }
   
    void UnitSelection(Vector3? groundLocation, GameObject objectHit)
    {
        if (buildButtonPressed == false && !skipSelection)
        {
            if (buildModeOn)
            {
                SetBuildMode(false);
            }
            else
            {
                if (objectHit == null || groundLocation.HasValue || !CompareTag(objectHit.tag))
                {
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        ClearAllSelectedUnits();
                        Debug.Log("No more selected.");
                    }
                }
                else if (objectHit != null && !selectedUnits.Contains(objectHit))
                {
                    
                    bool shallSkip = false;
                    if (selectedUnits.Count == 1)
                    {
                        if (selectedUnits[0].GetComponent<GuyMovement>().isABuilding)
                        {
                            ClearAllSelectedUnits();
                            SelectUnit(objectHit);
                            shallSkip = true;
                        }
                    }
                    if (!shallSkip)
                    {
                        if (objectHit.GetComponent<GuyMovement>().isABuilding == false && Input.GetKey(KeyCode.LeftShift))
                        {
                            SelectUnit(objectHit);
                            Debug.Log("I am selected with shift.");
                        }
                        else
                        {
                            ClearAllSelectedUnits();
                            SelectUnit(objectHit);
                            Debug.Log("I am a selected unit or building.");
                        }
                    }
                }
                else if (selectedUnits.Contains(objectHit))
                {
                    ClearAllSelectedUnits();
                    SelectUnit(objectHit);
                }
            }
        }
        else
        {
            buildButtonPressed = false;
            skipSelection = false;
        }
        Debug.Log(selectedUnits.Count);
        EditDisplay();

    }

    public void EditDisplay()
    {
        foreach (var button in housedUnitButtons)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }
        //This is for the UI Build Buttons changing
        if (selectedUnits.Count == 1)
        {
            displayInfo.ResetDisplay();
            GuyMovement unitAction = selectedUnits[0].GetComponent<GuyMovement>();
            int x = 0;
            if (unitAction.currentAction == UnitActions.Research)
            {
                foreach (var asdf in unitActionButtons)
                {
                    asdf.onClick.RemoveAllListeners();
                    asdf.GetComponentInChildren<TextMeshProUGUI>().text = "X";
                }
                var tMPro = unitActionButtons[8].GetComponentInChildren<TextMeshProUGUI>();
                tMPro.text = "Cancel";
                unitActionButtons[8].onClick.AddListener(() =>
                {
                    StopResearch(unitAction);
                });

            }
            else
            {
                for (int i = 0; i < unitActionButtons.Length; i++)
                {
                    unitActionButtons[i].onClick.RemoveAllListeners();
                    var tMPro = unitActionButtons[i].GetComponentInChildren<TextMeshProUGUI>();

                    if (i > unitAction.UnitGameObjects.Count - 1)
                    {
                        tMPro.text = "X";
                        if (unitAction.isABuilding)
                        {
                            Building buildingActions = unitAction.GetComponent<Building>();
                            if (x > buildingActions.researchableTechnology.Count - 1)
                            {
                            }
                            else
                            {
                                ITech tech = buildingActions.researchableTechnology[x];
                                
                                tMPro.text = tech.ToString();
                                unitActionButtons[i].onClick.AddListener(() =>
                                {
                                    UnitResearch(buildingActions, tech);
                                });
                                x++;
                            }

                        }
                    }
                    else
                    {
                        tMPro.text = unitAction.UnitTypes[i].ToString();
                        GameObject newGameObject = unitAction.UnitGameObjects[i];
                        unitActionButtons[i].onClick.AddListener(() =>
                        {
                            BuildButtonPressed(newGameObject);
                        });
                    }

                }

                if (unitAction.isABuilding)
                {
                    Building buildingActions = unitAction.GetComponent<Building>();

                    if (buildingActions.unitQueue.Count >= 1)
                    {

                        for (int i = 0; i <= buildingActions.unitQueue.Count - 1; i++)
                        {
                            GuyMovement uInQAction = buildingActions.unitQueue[i].GetComponent<GuyMovement>();
                            buildQueueButtons[i].onClick.RemoveAllListeners();
                            buildQueueButtons[i].gameObject.SetActive(true);
                            buildQueueButtons[i].image.sprite = uInQAction.unitImage;
                            int j = i;
                            GuyMovement guyMovement = unitAction;
                            buildQueueButtons[i].onClick.AddListener(() =>
                            {
                                BuildQueueAction(j, buildingActions);
                            });
                        }
                    }
                    if (unitAction.TryGetComponent(out Tower tower))
                    {

                        for (int i = 0; i <= tower.housedUnits.Count - 1; i++)
                        {
                            GuyMovement housedUnitAction = tower.housedUnits[i].GetComponent<GuyMovement>();
                            housedUnitButtons[i].onClick.RemoveAllListeners();
                            housedUnitButtons[i].gameObject.SetActive(true);
                            housedUnitButtons[i].image.sprite = housedUnitAction.unitImage;
                            int j = i;
                            GameObject housedUnit = tower.housedUnits[i];
                            housedUnitButtons[i].onClick.AddListener(() =>
                            {
                                tower.RemoveUnit(j, housedUnit);
                            });
                        }

                    }

                }
                else
                {
                    foreach (var button in buildQueueButtons)
                    {
                        button.gameObject.SetActive(false);
                    }
                }

            }
        }
        else
        {
            foreach (var button in unitActionButtons)
            {
                button.onClick.RemoveAllListeners();
                button.GetComponentInChildren<TextMeshProUGUI>().text = "X";

            }
        }

        //This is for the UI Unit Visual Buttons changing
        if (selectedUnits.Count > 1)
        {
            //unitImage.gameObject.SetActive(false);
            displayInfo.ResetDisplay();

            for (int i = 0; i < unitUIVisualButtons.Length; i++)
            {
                if (i > selectedUnits.Count - 1)
                {
                    unitUIVisualButtons[i].gameObject.SetActive(false);
                }
                else
                {
                    unitUIVisualButtons[i].gameObject.SetActive(true);
                    unitUIVisualButtons[i].onClick.RemoveAllListeners();
                    var unitAction = selectedUnits[i].GetComponent<GuyMovement>();
                    unitUIVisualButtons[i].image.sprite = unitAction.unitImage;
                    GameObject newGameObject = selectedUnits[i];
                    unitUIVisualButtons[i].onClick.AddListener(() =>
                    {
                        SelectionButtonAction(newGameObject);
                    });
                }
            }
        }
        else
        {
            foreach (var button in unitUIVisualButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
        //This is for the UI Unit Visual to become Single Unit Visual
        if (selectedUnits.Count == 1)
        {
            foreach (var button in unitUIVisualButtons)
            {
                button.gameObject.SetActive(false);
            }
            GuyMovement unitAction = selectedUnits[0].GetComponent<GuyMovement>();
            displayInfo.DisplayUnitInfo(unitAction);
        }
        else
        {
            displayInfo.ResetDisplay();
        }
    }

    void BuildQueueAction(int j, Building buildingAction)
    {
        skipSelection = true;
        buildingAction.RemoveUnitFromQueue(j);       
    }

    public void SelectionButtonAction(GameObject selectedGameObject)
    {       
        skipSelection = true;
        ClearAllSelectedUnits();
        SelectUnit(selectedGameObject);
    }

    public void Deselect(GameObject unit)
    {
        foreach(GameObject selected in selectedUnits)
        {
            if (selected == unit) 
            {
                var unitAction = unit.GetComponent<GuyMovement>();
                unitAction.hPNonUIVisAid.gameObject.SetActive(false);
                if (unitAction.isABuilding)
                {
                    if (unitAction.currentAction == UnitActions.Build || unitAction.currentAction == UnitActions.Research)
                    {
                        unitAction.BuildingActions.buildTimeVisGO.SetActive(false);
                    }
                }
                selectedUnits.Remove(unit);                
                EditDisplay();
                break;
            }
        }

    }
    void ClearAllSelectedUnits()
    {
        foreach(var unit in selectedUnits)
        {
            var unitAction = unit.GetComponent<GuyMovement>();
            unitAction.hPNonUIVisAid.gameObject.SetActive(false);
            if(unitAction.isABuilding)
            {
                if (unitAction.currentAction == UnitActions.Build || unitAction.currentAction == UnitActions.Research)
                {
                    unitAction.BuildingActions.buildTimeVisGO.SetActive(false);
                }
            }
            unitAction.isSelected = false;
        }
        selectedUnits.Clear();
    }

    void SelectUnit(GameObject unit)
    {
        GuyMovement unitAction = unit.GetComponent<GuyMovement>();
        unitAction.hPNonUIVisAid.gameObject.SetActive(true);
        unitAction.isSelected = true;
        if (!unitAction.isABuilding)
        {
            int i = Random.Range(0, unitAction.isSelectedAudio.Length);
            PlaySound(unitAction.isSelectedAudio[i]);
        }
        else
        {
            if (unitAction.currentAction == UnitActions.Build || unitAction.currentAction == UnitActions.Research)
            {
                unitAction.BuildingActions.buildTimeVisGO.SetActive(true);
            }
        }
        selectedUnits.Add(unit);
    }

    bool buttonActionOn = false;

    public void ButtonActionWait()
    {
        buttonActionOn = true;
        StartCoroutine(ButtonActionCoolDown());
    }

    IEnumerator ButtonActionCoolDown()
    {
        yield return new WaitForSeconds(1);
        buttonActionOn = false;
    }


    private void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void UnitResearch(Building buildingAction, ITech t)
    {

        skipSelection = true;
        if (buildingAction.GMovement.currentAction != UnitActions.Research)
        {
            buildingAction.Research(t);
        }
        else
        {
            Debug.Log("Currently Researching");
        }
    }
    public void StopResearch(GuyMovement unitAction)
    {
        skipSelection = true;
        unitAction.BuildingActions.StopResearch();
    }


}
