using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITech
{
    public TechType techType { get;}
    public int level { get; }
    public int woodCost { get; }
    public int gemCost { get; }
    public int foodCost { get; }

    public List<UnitType> RequiredUnitType { get;}
    public List<ITech> RequiredTechnologies { get;}


}

public class MountHPTechI : ITech
{
    public TechType techType => TechType.MountHP;
    public int level => 1;
    public int woodCost => 0;
    public int gemCost => 100;
    public int foodCost => 150;

    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MountHPTechI() 
    {
        requiredUnitType.Add(UnitType.Stables);
    }

}

public class MountHPTechII : ITech
{
    public TechType techType => TechType.MountHP;
    public  int level => 2;
    public  int woodCost => 0;
    public  int gemCost => 200;
    public  int foodCost => 300;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MountHPTechII(MountHPTechI mHPTI)
    {
        requiredUnitType.Add(UnitType.Stables);
        requiredTechnologies.Add(mHPTI);
    }
}
public class MeleeTechI : ITech
{
    public TechType techType => TechType.Melee;
    public int level => 1;
    public int woodCost => 150;
    public int gemCost => 100;
    public int foodCost => 0;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MeleeTechI()
    {
    }
}
public class MeleeTechII : ITech
{
    public TechType techType => TechType.Melee;
    public int level => 2;
    public int woodCost => 300;
    public int gemCost => 200;
    public int foodCost => 0;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MeleeTechII(MeleeTechI mTI)
    {
        requiredUnitType.Add(UnitType.Library);
        requiredTechnologies.Add(mTI);
    }
}

public class BowDamageTechI : ITech
{
    public TechType techType => TechType.BowDamage;
    public int level => 1;
    public int woodCost => 150;
    public int gemCost => 100;
    public int foodCost => 0;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public BowDamageTechI()
    {
    }
}
public class BowDamageTechII : ITech
{
    public TechType techType => TechType.BowDamage;
    public int level => 2;
    public int woodCost => 300;
    public int gemCost => 200;
    public int foodCost => 0;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public BowDamageTechII(BowDamageTechI bDTI)
    {
        requiredUnitType.Add(UnitType.Library);
        requiredTechnologies.Add(bDTI);
        Debug.Log(RequiredTechnologies[0] + " exists. Yippee!");
    }
}
public class MagicDamageTechI : ITech
{
    public TechType techType => TechType.MagicDamage;
    public int level => 1;
    public int woodCost => 0;
    public int gemCost => 300;
    public int foodCost => 150;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MagicDamageTechI()
    {
    }
}
public class MagicDamageTechII : ITech
{
    public TechType techType => TechType.MagicDamage;
    public int level => 2;
    public int woodCost => 00;
    public int gemCost => 600;
    public int foodCost => 300;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MagicDamageTechII(MagicDamageTechI mDTI)
    {
        requiredUnitType.Add(UnitType.WizardTower);
        requiredTechnologies.Add(mDTI);
    }
}
public class ArmorTechI : ITech
{
    public TechType techType => TechType.Armor;
    public int level => 1;
    public int woodCost => 50;
    public int gemCost => 150;
    public int foodCost => 50;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public ArmorTechI()
    {
    }

}
public class ArmorTechII : ITech
{
    public TechType techType => TechType.Armor;
    public int level => 2;
    public int woodCost => 100;
    public int gemCost => 300;
    public int foodCost => 100;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public ArmorTechII(ArmorTechI aTI)
    {
        requiredUnitType.Add(UnitType.Library);
        requiredTechnologies.Add(aTI);
    }
}
public class MountArmorTechI : ITech
{
    public TechType techType => TechType.MountArmor;
    public int level => 1;
    public int woodCost => 50;
    public int gemCost => 150;
    public int foodCost => 50;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MountArmorTechI(ArmorTechI aTI)
    {
        requiredUnitType.Add(UnitType.Stables);
        requiredTechnologies.Add(aTI);
    }

}
public class MountArmorTechII : ITech
{
    public TechType techType => TechType.MountArmor;
    public int level => 2;
    public int woodCost => 100;
    public int gemCost => 300;
    public int foodCost => 100;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public MountArmorTechII(MountArmorTechI mATI, ArmorTechII aTII)
    {
        requiredUnitType.Add(UnitType.WizardTower);
        requiredUnitType.Add(UnitType.Library);

        requiredTechnologies.Add(mATI);
        requiredTechnologies.Add(aTII);

    }
}
public class StructureTechI : ITech
{
    public TechType techType => TechType.Structure;
    public int level => 1;
    public int woodCost => 300;
    public int gemCost => 150;
    public int foodCost => 100;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public StructureTechI()
    {
    }

}
public class StructureTechII : ITech
{
    public TechType techType => TechType.Structure;
    public int level => 2;
    public int woodCost => 600;
    public int gemCost => 300;
    public int foodCost => 200;
    List<UnitType> requiredUnitType = new List<UnitType>();
    List<ITech> requiredTechnologies = new List<ITech>();
    public List<UnitType> RequiredUnitType => requiredUnitType;
    public List<ITech> RequiredTechnologies => requiredTechnologies;
    public StructureTechII(StructureTechI sTI)
    {
        requiredUnitType.Add(UnitType.Library);
        requiredTechnologies.Add(sTI);
    }
}

