using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color coveredColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f,0.5f,0f);


    TextMeshPro textMeshPro;
    Vector2Int coordinates = new Vector2Int();
   
    GridManager gridManager;
    //Waypoint waypoint;    

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        //waypoint = GetComponentInParent<Waypoint>();

        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.enabled = false;
        DisplayCoordinates();
    }

    void Update()
    {

        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();

        ToggleLabels();

    }

    private void SetLabelColor()
    {
        //textMeshPro.color = coveredColor;
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }
        if (!node.isWalkable)
        { 
            textMeshPro.color = coveredColor;
        }
        else if(node.isPath) 
        {
            textMeshPro.color = pathColor;
        }
        else if (node.isExplored)
        {
            textMeshPro.color = exploredColor;
        }
        else
        {
            textMeshPro.color = defaultColor;
        }

        //if (waypoint.IsPlaceable)
        //{
        //    textMeshPro.color = defaultColor;
        //}
        //else
        //{
        //    textMeshPro.color = coveredColor;
        //}
    }

    void ToggleLabels()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            textMeshPro.enabled = !textMeshPro.enabled;

        }
    }

    void DisplayCoordinates()
    {
        if(gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.position.z / gridManager.UnityGridSize);
        textMeshPro.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

}
