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

}

public class HealthTechI : ITech
{
    public TechType techType => TechType.Health;
    public virtual int level => 1;
    public int woodCost => 0;
    public virtual int gemCost => 100;
    public virtual int foodCost => 150;

}

public class HealthTechII : ITech
{
    public TechType techType => TechType.Health;
    public  int level => 2;
    public  int woodCost => 0;
    public  int gemCost => 200;
    public  int foodCost => 300;
}
public class WeaponTechI : ITech
{
    public TechType techType => TechType.Weapon;
    public int level => 1;
    public int woodCost => 150;
    public int gemCost => 100;
    public int foodCost => 0;
}
public class WeaponTechII : ITech
{
    public TechType techType => TechType.Weapon;
    public int level => 2;
    public int woodCost => 300;
    public int gemCost => 200;
    public int foodCost => 0;
}
public class ArmorTechI : ITech
{
    public TechType techType => TechType.Armor;
    public int level => 1;
    public int woodCost => 50;
    public int gemCost => 150;
    public int foodCost => 50;

}
public class ArmorTechII : ITech
{
    public TechType techType => TechType.Armor;
    public int level => 2;
    public int woodCost => 100;
    public int gemCost => 300;
    public int foodCost => 100;
}

