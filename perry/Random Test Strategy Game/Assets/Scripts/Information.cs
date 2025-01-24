using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Information : MonoBehaviour
{
    UnitLibrary uLib;
    List<ITech> technologies = new List<ITech>();
    public List<ITech> Technologies { get { return technologies; } }
    WeaponTechI WeaponI = new WeaponTechI();
    WeaponTechII WeaponII = new WeaponTechII();
    ArmorTechI ArmorI = new ArmorTechI();
    ArmorTechII ArmorII = new ArmorTechII();
    HealthTechI HealthI = new HealthTechI();
    HealthTechII HealthII = new HealthTechII();
    //[SerializeField] Dictionary<Technology, GameObject> techGameObjects = new Dictionary<Technology, GameObject>();
    public List<ITech> viewableTech = new List<ITech>();
    List<ITech> currentlyResearchedTech = new List<ITech>();

    private void Awake()
    {
        uLib = GetComponent<UnitLibrary>();
        viewableTech.Add(WeaponI);
        viewableTech.Add(ArmorI);
        
    }
    private void Start()
    {
        EditViewableTech();
    }
    public void Research(TechType tech)
    {
        ITech it = HealthI;
        foreach(ITech IT in viewableTech)
        {
            if(IT.techType == tech)
            {
                it = IT;
            }
        }
        viewableTech.Remove(it);
        currentlyResearchedTech.Add(it);
        EditViewableTech();
    }
    public void StopResearch(TechType tech)
    {
        ITech it = HealthI;
        foreach (ITech IT in currentlyResearchedTech)
        {
            if (IT.techType == tech)
            {
                it = IT;
            }
        }
        viewableTech.Add(it);
        EditViewableTech();
    }

    void EditViewableTech()
    {
        foreach(GuyMovement blackSmith in uLib.blackSmiths)
        {
            blackSmith.BuildingActions.researchableTechnology = viewableTech;
        }
    }

    
    public void ResearchCompletion(TechType t)
    {
        if (t == TechType.Armor)
        {
            if (technologies.Contains(ArmorI))
            {
                technologies.Add(ArmorII);
            }
            else
            {
                technologies.Add(ArmorI);
            }
            foreach (var guy in uLib.Units())
            {
                guy.bonusArmor += 3;
            }
        }
        else if (t == TechType.Weapon)
        {
            if (technologies.Contains(WeaponI))
            {
                technologies.Add(WeaponII);
            }
            else
            {
                technologies.Add(WeaponI);
                viewableTech.Add(WeaponII);
            }

            foreach (var guy in uLib.Units())
            {
                guy.bonusAttackDamage += 2;
            }
        }
        else if (t == TechType.Health)
        {
            if (technologies.Contains(HealthI))
            {
                technologies.Add(HealthII);
            }
            else
            {
                technologies.Add(HealthI);
                viewableTech.Add(HealthII);
            }
            foreach (var guy in uLib.Units())
            {
                guy.maxHealth += 10;
                guy.currentHealth += 10;
                guy.bonusHealth += 10;
            }
        }
        GetComponent<PlayerController>().EditDisplay();

    }

}
