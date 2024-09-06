using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {  get { return isPlaceable; } }
    
    GridManager gridManager;
    PathFinding pathFinding;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinding = FindObjectOfType<PathFinding>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockPath(coordinates);
            }

        }
    }


    void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinding.WillBlockPath(coordinates))
        {
            bool isSuccessful = tower.CreateTower(tower, transform.position);

            //isPlaceable = !isPlaced;
            if (isSuccessful)
            {
                gridManager.BlockPath(coordinates);
                pathFinding.NotifyReceivers();
            }
        }
    }

}
