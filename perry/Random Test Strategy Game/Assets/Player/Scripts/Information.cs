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
   
    MeleeTechI MeleeI = new MeleeTechI();
    MeleeTechII MeleeII;
    
    BowDamageTechI BowDamageI = new BowDamageTechI();
    BowDamageTechII BowDamageII;
    
    MagicDamageTechI MagicDamageI = new MagicDamageTechI();
    MagicDamageTechII MagicDamageII;

    ArmorTechI ArmorI = new ArmorTechI();
    ArmorTechII ArmorII;
    
    MountArmorTechI MountArmorI;
    MountArmorTechII MountArmorII;

    MountHPTechI MountHPI = new MountHPTechI();
    MountHPTechII MountHPII;

    public List<ITech> viewableBlacksmithTech = new List<ITech>();
    public List<ITech> viewableLibraryTech = new List<ITech>();
    List<ITech> currentlyResearchedTech = new List<ITech>();

    private void Awake()
    {
        uLib = GetComponent<UnitLibrary>();
       
        MeleeII = new MeleeTechII(MeleeI);
        BowDamageII = new BowDamageTechII(BowDamageI);
        MagicDamageII = new MagicDamageTechII(MagicDamageI);
        ArmorII = new ArmorTechII(ArmorI);
        MountArmorI = new MountArmorTechI(ArmorI);
        MountArmorII = new MountArmorTechII(MountArmorI,ArmorII);        
        MountHPII = new MountHPTechII(MountHPI);

        viewableBlacksmithTech.Add(MeleeI);
        viewableBlacksmithTech.Add(BowDamageI);
        viewableBlacksmithTech.Add(ArmorI);
        viewableBlacksmithTech.Add(MountArmorI);

        viewableLibraryTech.Add(MountHPI);
        viewableLibraryTech.Add(MagicDamageI);

        //Debug.Log(BowDamageII.requiredTechnologies[0] + " exists. Yippee!");
    }
    
    private void Start()
    {

        EditViewableTech();
    }
    public void Research(TechType tech)
    {
        ITech it = null;
        foreach(ITech IT in viewableBlacksmithTech)
        {
            if(IT.techType == tech)
            {
                it = IT;
                viewableBlacksmithTech.Remove(it);
                break;
            }
        }
        foreach (ITech IT in viewableLibraryTech)
        {
            if (IT.techType == tech)
            {
                it = IT;
                viewableLibraryTech.Remove(it);
                break;
            }
        }
        currentlyResearchedTech.Add(it);
        EditViewableTech();
    }
    public void StopResearch(TechType tech, UnitType unitType)
    {
        ITech it = MountHPI;
        foreach (ITech IT in currentlyResearchedTech)
        {
            if (IT.techType == tech)
            {
                it = IT;
            }
        }
        if(unitType == UnitType.BlackSmith)
        {
            viewableBlacksmithTech.Add(it);
        }
        else
        {
            viewableLibraryTech.Add(it);
        }
        EditViewableTech();
    }

    public void EditViewableTech()
    {
        foreach (GuyMovement blackSmith in uLib.blackSmiths)
        {
            Building building = blackSmith.GetComponent<Building>();
            building.researchableTechnology = viewableBlacksmithTech;
        }
        foreach (GuyMovement library in uLib.libraries)
        {
            Building building = library.GetComponent<Building>();
            building.researchableTechnology = viewableLibraryTech;
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
                viewableBlacksmithTech.Add(ArmorII);
            }
            foreach (var guy in uLib.ArmoredUnits())
            {
                guy.bonusArmor += 3;
            }
        }
        else if (t == TechType.MountArmor)
        {
            if (technologies.Contains(MountArmorI))
            {
                technologies.Add(MountArmorII);
            }
            else
            {
                technologies.Add(MountArmorI);
                viewableBlacksmithTech.Add(MountArmorII);
            }
            foreach (var guy in uLib.MountedUnits())
            {
                guy.bonusArmor += 3;
            }
        }
        else if (t == TechType.Melee)
        {
            if (technologies.Contains(MeleeI))
            {
                technologies.Add(MeleeII);
            }
            else
            {
                technologies.Add(MeleeI);
                viewableBlacksmithTech.Add(MeleeII);
            }

            foreach (var guy in uLib.MeleeUnits())
            {
                guy.bonusAttackDamage += 2;
            }
        }
        else if (t == TechType.BowDamage)
        {
            if (technologies.Contains(BowDamageI))
            {
                technologies.Add(BowDamageII);
            }
            else
            {
                technologies.Add(BowDamageI);
                viewableBlacksmithTech.Add(BowDamageII);
            }

            foreach (var guy in uLib.RangedUnits())
            {
                guy.bonusAttackDamage += 2;
            }
        }
        else if (t == TechType.MagicDamage)
        {
            if (technologies.Contains(MagicDamageI))
            {
                technologies.Add(MagicDamageII);
            }
            else
            {
                technologies.Add(MagicDamageI);
                viewableBlacksmithTech.Add(MagicDamageII);
            }

            foreach (var guy in uLib.MagicUnits())
            {
                guy.bonusAttackDamage += 2;
            }
        }
        else if (t == TechType.MountHP)
        {
            if (technologies.Contains(MountHPI))
            {
                technologies.Add(MountHPII);
            }
            else
            {
                technologies.Add(MountHPI);
                viewableBlacksmithTech.Add(MountHPII);
            }
            foreach (var guy in uLib.MountedUnits())
            {
                guy.maxHealth += 10;
                guy.currentHealth += 10;
                guy.bonusHealth += 10;
            }
        }
        foreach(ITech tec in technologies) 
        {
            Debug.Log(tec.techType);
        }
        //GetComponent<PlayerController>().EditDisplay();

    }

    public string CheckRequirements(ITech tech)
    {
        Debug.Log("I Here");

        string requirements = " ";

        foreach(ITech requiredTech in tech.RequiredTechnologies)
        {
            Debug.Log(requiredTech.techType);
            if (!currentlyResearchedTech.Contains(requiredTech))
            {
                Debug.Log("I check Requirements");
                if (requirements != " ")
                {
                    requirements += $" and {requiredTech}";
                }
                else
                {
                    requirements += requiredTech;
                }              
            }
        }
        string uTypesString = uLib.CheckRequirements(tech.RequiredUnitType);
        if(uTypesString != null)
        {
            if(requirements == " ")
            {
                requirements += uTypesString;
            }
            else 
            {
                requirements += $"; {uTypesString}";
            }
        }
        if (requirements != " ") return requirements; else return null;
    }
}
