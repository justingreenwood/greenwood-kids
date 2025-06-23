using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquares 
{
    public Vector2Int position { get; private set; }
    public bool isClaimed = false;
    public bool hasBeenSeen = false;
    public GameObject block;


    public GridSquares(Vector2Int position)
    {
        this.position = position;
    }



}
