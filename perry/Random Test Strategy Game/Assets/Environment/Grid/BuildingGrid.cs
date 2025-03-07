using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrid : MonoBehaviour
{

    [SerializeField] int width;
    [SerializeField] int depth;

    
    public List<GridSquares> gridSquares = new List<GridSquares>();
    public Dictionary<Vector2Int, bool> gridSqrsDict = new Dictionary<Vector2Int, bool>();

    private void Awake()
    {        
        for (int i = 0; i < width; i+=4)
        {
            for (int j = 0; j < depth / 4; j+=4)
            {
                Vector2Int v2Int = new Vector2Int(i, j);
                gridSquares.Add(new GridSquares(v2Int));

            }
        }
        foreach (GridSquares square in gridSquares)
        {
            gridSqrsDict.Add(square.position, false);
        }

    }

    private void Update()
    {
        
        

    }

}
