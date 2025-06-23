using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrid : MonoBehaviour
{

    [SerializeField] int width;
    [SerializeField] int depth;
    [SerializeField] GameObject blockPrefab;
    
    public List<GridSquares> gridSquares = new List<GridSquares>();
    public Dictionary<Vector2Int, bool> gridSqrsDict = new Dictionary<Vector2Int, bool>();

    private void Awake()
    {        
        for (int i = 0; i < width; i+=4)
        {
            for (int j = 0; j < depth; j+=4)
            {
                Vector3Int v3Int = new Vector3Int(i+2,6,j+2);
                Vector2Int v2Int = new Vector2Int(i, j);
                GridSquares newGridSquare = new GridSquares(v2Int);
                GameObject block = Instantiate(blockPrefab, v3Int, Quaternion.identity);
                newGridSquare.block = block;
                gridSquares.Add(newGridSquare);

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
