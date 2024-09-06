using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

    string team;
    ResourceBank resourceBank;
    public int unitsAlive = 0;
    List<GameObject> builderUnits = new List<GameObject>();
    List<GameObject> buildings = new List<GameObject>();
    List<GameObject> manAtArmsUnits = new List<GameObject>();


    void Start()
    {
        team = gameObject.tag;
        resourceBank = gameObject.GetComponent<ResourceBank>();

        GuyMovement[] units = FindObjectsOfType<GuyMovement>();

        foreach (GuyMovement unit in units)
        {
            if (CompareTag(unit.gameObject.tag))
            {
                if (unit.isABuilding)
                {
                    buildings.Add(unit.gameObject);
                }
                else if (unit.isBuilder)
                {
                    builderUnits.Add(unit.gameObject);
                }
                else
                {
                    manAtArmsUnits.Add(unit.gameObject);
                }
            }


        }

    }

    void Update()
    {
        
    }
}
