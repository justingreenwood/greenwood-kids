using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] int resources = 100;
    public int Resources {  get { return resources; } }
    [SerializeField] ResourceType resourceType;
    public ResourceType Type { get {  return resourceType; } }
    BuildingGrid buildingGrid;
    Vector2Int vTwoPosition;
    private void Start()
    {
        buildingGrid = FindObjectOfType<BuildingGrid>();
        vTwoPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        buildingGrid.gridSqrsDict[vTwoPosition] = true;
    }

    private void Update()
    {
        
        if (resources <= 0)
        {
            buildingGrid.gridSqrsDict[vTwoPosition] = false;
            Destroy(gameObject);
        }
    }

    public int CollectResource(int amount)
    {
        if(resources>=amount)
        {
            resources -= amount;
            return amount;
        }
        else 
        {
            int newAmount = resources;
            resources = 0;
            return newAmount;
            
        }

    }

}
