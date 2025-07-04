using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class UnitLibrary : MonoBehaviour
{
    [SerializeField] public List<GuyMovement> peasants = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> houses = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> castles = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> farmland = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> trainingFields = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> stables = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> menAtArms = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> archers = new List<GuyMovement>();

    [SerializeField] public List<GuyMovement> knights = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> lightCavalry = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> wizardTowers = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> pegasusStables = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> libraries = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> blackSmiths = new List<GuyMovement>();

    [SerializeField] public List<GuyMovement> wizards = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> rangedCavalry = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> pegasusArchers = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> dragons = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> pegasusKnights = new List<GuyMovement>();
    [SerializeField] public List<GuyMovement> towers = new List<GuyMovement>();

    Dictionary<UnitType, bool> unitTypeDict = new Dictionary<UnitType, bool>();

    private void Awake()
    {
        GuyMovement[] units = FindObjectsOfType<GuyMovement>();

        foreach (GuyMovement unit in units)
        {
            if (CompareTag(unit.gameObject.tag))
            {
                AddUnit(unit);

            }


        }
    }
    void Start()
    {
        Debug.Log(unitTypeDict.Count+" dict count");
        foreach(var asdf in unitTypeDict.Values)
        {
            Debug.Log(asdf.ToString());
        }
    }

    public void AddUnit(GuyMovement unitAction)
    {
        switch(unitAction.unitType)
        {
            case UnitType.Archer:
                archers.Add(unitAction);
                break;
            case UnitType.BlackSmith:
                blackSmiths.Add(unitAction);
                break;
            case UnitType.Peasant:
                peasants.Add(unitAction);
                break;
            case UnitType.Castle:
                castles.Add(unitAction);
                break;
            case UnitType.PegasusStables:
                pegasusStables.Add(unitAction);
                break;
            case UnitType.Dragon:
                dragons.Add(unitAction);
                break;
            case UnitType.FarmLand:
                farmland.Add(unitAction);
                break;
            case UnitType.House:
                houses.Add(unitAction);
                break;
            case UnitType.Knight:
                knights.Add(unitAction);
                break;
            case UnitType.Library:
                libraries.Add(unitAction);
                break;
            case UnitType.LightCavalry:
                lightCavalry.Add(unitAction);
                break;
            case UnitType.ManAtArms:
                menAtArms.Add(unitAction);
                break;
            case UnitType.PegasusArcher:
                pegasusArchers.Add(unitAction);
                break;
            case UnitType.PegasusKnight:
                pegasusKnights.Add(unitAction);
                break;
            case UnitType.RangedCavalry:
                rangedCavalry.Add(unitAction);
                break;
            case UnitType.Stables:
                stables.Add(unitAction);
                break;
            case UnitType.Tower:
                towers.Add(unitAction);
                break;
            case UnitType.TrainingField:
                trainingFields.Add(unitAction);
                break;
            case UnitType.Wizard:
                wizards.Add(unitAction);
                break;
            case UnitType.WizardTower:
                wizardTowers.Add(unitAction);
                break;           
        }
        if (!unitTypeDict.ContainsKey(unitAction.unitType))
        {
            unitTypeDict.Add(unitAction.unitType, true);
        }
        else 
        { 
            unitTypeDict[unitAction.unitType] = true; 
        }
        
    }

    public void RemoveUnit(GuyMovement unitAction)
    {
        List<GuyMovement> list = archers;
        switch (unitAction.unitType)
        {
            case UnitType.BlackSmith:
                list = blackSmiths;
                break;
            case UnitType.Peasant:
                list = list = peasants;
                break;
            case UnitType.Castle:
                list = castles;
                break;
            case UnitType.PegasusStables:
                list = pegasusStables;
                break;
            case UnitType.Dragon:
                list = dragons;
                break;
            case UnitType.FarmLand:
                list = farmland;
                break;
            case UnitType.House:
                list = houses;
                break;
            case UnitType.Knight:
                list = knights;
                break;
            case UnitType.Library:
                list = libraries;
                break;
            case UnitType.LightCavalry:
                list = lightCavalry;
                break;
            case UnitType.ManAtArms:
                list = menAtArms;
                break;
            case UnitType.PegasusArcher:
                list = pegasusArchers;
                break;
            case UnitType.PegasusKnight:
                list = pegasusKnights;
                break;
            case UnitType.RangedCavalry:
                list = rangedCavalry;
                break;
            case UnitType.Stables:
                list = stables;
                break;
            case UnitType.Tower:
                list = towers;
                break;
            case UnitType.TrainingField:
                list = trainingFields;
                break;
            case UnitType.Wizard:
                list = wizards;
                break;
            case UnitType.WizardTower:
                list = wizardTowers;
                break;

        }

        foreach (var unit in from unit in list where unit == unitAction select unit)
        {
            list.Remove(unit);
            if(list.Count == 0)
            {
                
                unitTypeDict[unitAction.unitType] = false;
            }
            break;
        }
        
    }

    public string CheckRequirements(List<UnitType> FRS)
    {
        string requirements = "";
        foreach (var unit in FRS)
        {
            Debug.Log(unit + " checked");
            if (!unitTypeDict.ContainsKey(unit))
            {
                Debug.Log(unit + " checked again");
                unitTypeDict.Add(unit, false);
                requirements += $"{unit} ";
            }
            else if (unitTypeDict[unit] == false) 
            {

                requirements += $"{unit} ";
            }           
        }
        if (requirements != "")return requirements;else return null;

    }
    public List<GuyMovement> UnitsMinusPeasants()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(archers);
        list.AddRange(menAtArms);
        list.AddRange(wizards);
        list.AddRange(knights);
        list.AddRange(lightCavalry);
        list.AddRange(rangedCavalry);
        list.AddRange(pegasusArchers);
        list.AddRange(pegasusKnights);
        list.AddRange(dragons);
        return list;
    }
    public List<GuyMovement> Units()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(archers);
        list.AddRange(peasants);
        list.AddRange(menAtArms);
        list.AddRange(wizards);
        list.AddRange(knights);
        list.AddRange(lightCavalry);
        list.AddRange(rangedCavalry);
        list.AddRange(pegasusArchers);
        list.AddRange(pegasusKnights);
        list.AddRange(dragons);
        return list;
    }
    public List<GuyMovement> MeleeUnits()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(peasants);
        list.AddRange(menAtArms);
        list.AddRange(knights);
        list.AddRange(lightCavalry);
        list.AddRange(pegasusKnights);
        return list;
    }
    public List<GuyMovement> RangedUnits()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(archers);
        list.AddRange(rangedCavalry);
        list.AddRange(pegasusArchers);
        return list;
    }
    public List<GuyMovement> MountedUnits()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(knights);
        list.AddRange(lightCavalry);
        list.AddRange(rangedCavalry);
        list.AddRange(pegasusArchers);
        list.AddRange(pegasusKnights);
        list.AddRange(dragons);
        return list;
    }
    public List<GuyMovement> ArmoredUnits()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(archers);
        list.AddRange(peasants);
        list.AddRange(menAtArms);
        list.AddRange(wizards);
        list.AddRange(knights);
        return list;
    }
    public List<GuyMovement> MagicUnits()
    {
        List<GuyMovement> list = new List<GuyMovement>();
        list.AddRange(wizards);
        list.AddRange(dragons);
        return list;
    }
}
