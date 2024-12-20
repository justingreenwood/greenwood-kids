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
        for (int i = 0; i < width/4; i++)
        {
            for (int j = 0; j < depth / 4; j++)
            {
                gridSquares.Add(new GridSquares(new Vector2Int(i * 4,j * 4)));
            }
        }  
        foreach (GridSquares square in gridSquares)
        {
            gridSqrsDict.Add(square.position, square.isClaimed);
        }
    }

    private void Update()
    {
        
        

    }

}
