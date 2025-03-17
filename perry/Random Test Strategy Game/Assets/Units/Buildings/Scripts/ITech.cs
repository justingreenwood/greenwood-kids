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

    public List<UnitType> requiredUnitType { get; }
    public List<ITech> requiredTechnologies { get; }


}

public class MountHPTechI : ITech
{
    public TechType techType => TechType.MountHP;
    public int level => 1;
    public int woodCost => 0;
    public int gemCost => 100;
    public int foodCost => 150;
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
    public BowDamageTechII(BowDamageTechI bDTI)
    {
        requiredUnitType.Add(UnitType.Library);
        requiredTechnologies.Add(bDTI);
    }
}
public class MagicDamageTechI : ITech
{
    public TechType techType => TechType.MagicDamage;
    public int level => 1;
    public int woodCost => 0;
    public int gemCost => 300;
    public int foodCost => 150;
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
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
    public List<UnitType> requiredUnitType => new List<UnitType>();
    public List<ITech> requiredTechnologies => new List<ITech>();
    public StructureTechII(StructureTechI sTI)
    {
        requiredUnitType.Add(UnitType.Library);
        requiredTechnologies.Add(sTI);
    }
}

