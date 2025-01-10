using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Information : MonoBehaviour
{
    UnitLibrary uLib;

    Dictionary<Technology, int> technologies = new Dictionary<Technology, int>();
    public Dictionary<Technology, int> Technologies { get { return technologies; } }
    //[SerializeField] Dictionary<Technology, GameObject> techGameObjects = new Dictionary<Technology, GameObject>();
    public List<Technology> viewableTech = new List<Technology>();


    private void Awake()
    {
        uLib = GetComponent<UnitLibrary>();
        technologies.Add(Technology.Weapon, 0);
        technologies.Add(Technology.Armor, 0);
        foreach (Technology tech in technologies.Keys)
        {
            viewableTech.Add(tech);
        }
    }
    private void Start()
    {
        EditViewableTech();
    }
    public void Research(Technology tech)
    {
        viewableTech.Remove(tech);
        EditViewableTech();
    }
    public void StopResearch(Technology tech)
    {
        viewableTech.Insert((int)tech, tech);
        EditViewableTech();
    }

    void EditViewableTech()
    {
        foreach(GuyMovement blackSmith in uLib.blackSmiths)
        {
            blackSmith.BuildingActions.researchableTechnology = viewableTech;
        }
    }

    
    public void ResearchCompletion(Technology t)
    {
        technologies[t] += 1;
        if (t == Technology.Armor)
        {
            foreach (var guy in uLib.Units())
            {
                guy.bonusArmor += 3;
            }
        }
        else if (t == Technology.Weapon)
        {
            foreach (var guy in uLib.Units())
            {
                guy.bonusAttackDamage += 2;
            }
        }
        //else if (t == Technology.Health)
        //{
        //    foreach (var guy in uLib.Units())
        //    {
        //        guy.maxHealth += 10;
        //        guy.currentHealth += 10;
        //        guy.bonusHealth += 10;
        //    }
        //}
        GetComponent<PlayerController>().EditDisplay();

    }

}
