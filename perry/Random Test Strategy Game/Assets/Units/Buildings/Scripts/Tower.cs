using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] public List<GameObject> housedUnits = new List<GameObject>();
    [SerializeField] int maxHouseUnits = 4;
    int archers = 0;
    GuyMovement guyMovement;

    void Start()
    {
        guyMovement = GetComponent<GuyMovement>();
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
        EditAttackSpeed();
    }

    private void EditAttackSpeed()
    {
        
        if(archers > 0)
        {

            guyMovement.finalAttackSpeed = guyMovement.attackSpeed / archers;
            guyMovement.targetsNearestEnemy = true;
        }
        else
        {
            guyMovement.StopActivities();
            guyMovement.target = null;
            guyMovement.targetsNearestEnemy = false;
        }
       
    
    }
    

    public void RemoveUnit(int i, GameObject target)
    {      
        target.SetActive(true);        
        if (target.GetComponent<GuyMovement>().unitType == UnitType.Archer)
        {
            archers--;
        }
        housedUnits.RemoveAt(i);
        EditAttackSpeed();
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
            unit.gameObject.SetActive(false);
            EditAttackSpeed();
            if (guyMovement.playerController != null)
            {
                guyMovement.playerController.EditDisplay();
            }
        }
    }






}
