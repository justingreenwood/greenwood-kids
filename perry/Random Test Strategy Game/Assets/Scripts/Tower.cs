using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class Tower : MonoBehaviour
{

    [SerializeField] List<GameObject> housedUnits = new List<GameObject>();
    [SerializeField] int maxHouseUnits = 4;
    int archers = 0;
    GuyMovement unitActions;

    void Start()
    {
        unitActions = GetComponent<GuyMovement>();
        foreach (GameObject unit in housedUnits)
        {
            if (unit.activeSelf)
            {
                unit.SetActive(false);
            }
            if(unit.GetComponent<GuyMovement>().unitType == UnitType.Archer)
            {
                archers++;
            }

        }
        EditDamage();
    }

    private void EditDamage()
    {
        unitActions.finalAttackDamage = unitActions.attackDamage * housedUnits.Count;
    
    }

    void Update()
    {
        


    }

    public void RemoveUnit(int i, GameObject target)
    {      
        target.SetActive(true);
        housedUnits.RemoveAt(i);
        if (target.GetComponent<GuyMovement>().unitType == UnitType.Archer)
        {
            archers--;
        }
        EditDamage();
    }

    public void AddUnit(GameObject unit)
    {
        if (housedUnits.Count < maxHouseUnits)
        {
            housedUnits.Add(unit);
            if (unit.GetComponent<GuyMovement>().unitType == UnitType.Archer)
            {
                archers++;
            }
            EditDamage();
        }
    }






}
