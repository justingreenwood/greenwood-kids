using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] int amountOfResource = 100;
    public int AmountOfResource {  get { return amountOfResource; } }    
    [SerializeField] ResourceType resourceType;
    public ResourceType ResourceType { get { return resourceType; } }
    [SerializeField] public Sprite image;
    public ResourceType Type { get {  return resourceType; } }
    public bool isSelected = false;
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
        
        if (amountOfResource <= 0)
        {
            buildingGrid.gridSqrsDict[vTwoPosition] = false;
            if (isSelected)
            {
                PlayerController PC = FindObjectOfType<PlayerController>();
                PC.selectedResource = null;
                PC.EditDisplay();
            }
            Destroy(gameObject);
        }
    }

    public int CollectResource(int amount)
    {
        if(amountOfResource>=amount)
        {
            amountOfResource -= amount;
            return amount;
        }
        else 
        {
            int newAmount = amountOfResource;
            amountOfResource = 0;
            return newAmount;           
        }

    }

}
