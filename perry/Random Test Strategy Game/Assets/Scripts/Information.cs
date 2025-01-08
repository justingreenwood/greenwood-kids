using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Information : MonoBehaviour
{
    UnitLibrary uLib;

    Dictionary<Technology, bool> technologies = new Dictionary<Technology, bool>();
    [SerializeField] Dictionary<Technology, GameObject> techGameObjects = new Dictionary<Technology, GameObject>();
    public List<Technology> viewableTech = new List<Technology>();
    private void Awake()
    {
        uLib = GetComponent<UnitLibrary>();
        technologies.Add(Technology.WeaponI, false);
        technologies.Add(Technology.WeaponII, false);
        technologies.Add(Technology.WeaponIII, false);
        technologies.Add(Technology.ArmorI, false);
        technologies.Add(Technology.ArmorII, false);
        technologies.Add(Technology.ArmorIII, false);
        foreach (Technology tech in technologies.Keys)
        {
            viewableTech.Add(tech);
        }
    }   
    public void Research(Technology tech)
    {
        viewableTech.Remove(tech);
        EditViewableTech(tech);
    }
    public void StopResearch(Technology tech)
    {
        viewableTech.Insert((int)tech, tech);
        EditViewableTech(tech);
    }

    void EditViewableTech(Technology tech)
    {
        foreach(GuyMovement blackSmith in uLib.blackSmiths)
        {
            blackSmith.BuildingActions.researchableTechnology = viewableTech;

        }
    }

    

}
