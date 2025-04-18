using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitTypeInformation
{
    public UnitType UnitType { get; }
    public int woodCost { get; }
    public int gemCost { get; }
    public int foodCost { get; }
    public int unitSize { get; }
    public int maxHealth { get; }
    public int armor { get; }
    public int healthIncreaseIncrement { get; }
    public float attackRange { get; }
    public float damage { get; }
    public float attackSpeed { get; }
    public float sightRange { get; }
    public float moveDelay { get; }//May Remove
    public TechType weaponType { get; }
    public TechType armorType { get; }
    public TechType healthType { get; }
    public TechType rangeType { get; }
    public bool isMovable { get; }
    public bool targetsNearestEnemy { get; }
    public bool canAttackFlying { get; }
    public bool isFlying { get; }
    public bool isABuilding { get; }//Hopefully will be obsolete.
    public bool isABuilder { get; }//Hopefully will be obsolete.
    public bool canProduceUnits { get; }//Hopefully will be obsolete.
    public Sprite unitImage { get; }
    public Material buildingMaterial { get; }
    public Renderer coloredPart { get; }//Hopefully will be changed.
    public List<UnitType> unitTypes { get; }//Hopefully will be changed.
    public List<GameObject> unitGameObjects { get; }//Hopefully will be changed.
    public List<UnitType> requiredStructures { get; }
    public AudioClip[] isSelectedAudio { get; }
    public AudioClip[] IncapableAudio { get; }
    public AudioClip[] ActionAudio { get; }

}
public class Archer : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Archer;

    public int woodCost => 20;

    public int gemCost => 0;

    public int foodCost => 50;

    public int unitSize => 1;

    public int maxHealth => 50;

    public int armor => 0;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 30;

    public float damage => 6.5f;

    public float attackSpeed => 2.3f;

    public float sightRange => 50;

    public float moveDelay => 0.5f;

    public TechType weaponType => TechType.BowDamage;

    public TechType armorType => TechType.Armor;

    public TechType healthType => TechType.Nothing;

    public TechType rangeType => TechType.BowRange;

    public bool isMovable => true;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => false;

    public bool isABuilding => false;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => new List<UnitType>();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Peasant : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Builder;

    public int woodCost => 0;

    public int gemCost => 0;

    public int foodCost => 50;

    public int unitSize => 1;

    public int maxHealth => 50;

    public int armor => 0;

    public int healthIncreaseIncrement => 1;
    public float moveDelay => 0.5f;
    public float attackRange => 3;

    public float damage => 3;

    public float attackSpeed => 0.75f;

    public float sightRange => 50;

    public TechType weaponType => TechType.Melee;

    public TechType armorType => TechType.Armor;

    public TechType healthType => TechType.Nothing;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => true;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => false;

    public bool isABuilder => true;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => new List<UnitType>();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();

    
}
public class Dragon : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Dragon;

    public int woodCost => 50;

    public int gemCost => 250;

    public int foodCost => 300;

    public int unitSize => 4;

    public int maxHealth => 1000;

    public int armor => 5;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 10;

    public float damage => 20;

    public float attackSpeed => 0.75f;

    public float sightRange => 50;

    public float moveDelay => 0.5f;

    public TechType weaponType => TechType.MagicDamage;

    public TechType armorType => TechType.MountArmor;

    public TechType healthType => TechType.MountHP;

    public TechType rangeType => TechType.MagicRange;

    public bool isMovable => true;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => true;

    public bool isABuilding => false;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => new List<UnitType>();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Knight : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Knight;

    public int woodCost => 25;

    public int gemCost => 0;

    public int foodCost => 200;

    public int unitSize => 1;

    public int maxHealth => 200;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 6;

    public float damage => 9;

    public float attackSpeed => 2.2f;

    public float sightRange => 50;

    public float moveDelay => 0.5f;

    public TechType weaponType => TechType.Melee;

    public TechType armorType => TechType.MountArmor;

    public TechType healthType => TechType.MountHP;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => true;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => false;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class ManAtArms : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.ManAtArms;

    public int woodCost => 0;

    public int gemCost => 0;

    public int foodCost => 50;

    public int unitSize => 1;

    public int maxHealth => 50;

    public int armor => 1;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 6;

    public float damage => 5;

    public float attackSpeed => 1.8f;

    public float sightRange => 50;

    public float moveDelay => 0.5f;

    public TechType weaponType => TechType.Melee;

    public TechType armorType => TechType.Armor;

    public TechType healthType => TechType.Nothing;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => true;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => false;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class PegasusArcher : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.PegasusArcher;

    public int woodCost => throw new System.NotImplementedException();

    public int gemCost => throw new System.NotImplementedException();

    public int foodCost => throw new System.NotImplementedException();

    public int unitSize => throw new System.NotImplementedException();

    public int maxHealth => throw new System.NotImplementedException();

    public int armor => throw new System.NotImplementedException();

    public int healthIncreaseIncrement => throw new System.NotImplementedException();

    public float attackRange => throw new System.NotImplementedException();

    public float damage => throw new System.NotImplementedException();

    public float attackSpeed => throw new System.NotImplementedException();

    public float sightRange => throw new System.NotImplementedException();

    public float moveDelay => throw new System.NotImplementedException();

    public TechType weaponType => throw new System.NotImplementedException();

    public TechType armorType => throw new System.NotImplementedException();

    public TechType healthType => throw new System.NotImplementedException();

    public TechType rangeType => throw new System.NotImplementedException();

    public bool isMovable => throw new System.NotImplementedException();

    public bool targetsNearestEnemy => throw new System.NotImplementedException();

    public bool canAttackFlying => throw new System.NotImplementedException();

    public bool isFlying => throw new System.NotImplementedException();

    public bool isABuilding => throw new System.NotImplementedException();

    public bool isABuilder => throw new System.NotImplementedException();

    public bool canProduceUnits => throw new System.NotImplementedException();

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class PegasusKnight : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.PegasusKnight;

    public int woodCost => throw new System.NotImplementedException();

    public int gemCost => throw new System.NotImplementedException();

    public int foodCost => throw new System.NotImplementedException();

    public int unitSize => throw new System.NotImplementedException();

    public int maxHealth => throw new System.NotImplementedException();

    public int armor => throw new System.NotImplementedException();

    public int healthIncreaseIncrement => throw new System.NotImplementedException();

    public float attackRange => throw new System.NotImplementedException();

    public float damage => throw new System.NotImplementedException();

    public float attackSpeed => throw new System.NotImplementedException();

    public float sightRange => throw new System.NotImplementedException();

    public float moveDelay => throw new System.NotImplementedException();

    public TechType weaponType => throw new System.NotImplementedException();

    public TechType armorType => throw new System.NotImplementedException();

    public TechType healthType => throw new System.NotImplementedException();

    public TechType rangeType => throw new System.NotImplementedException();

    public bool isMovable => throw new System.NotImplementedException();

    public bool targetsNearestEnemy => throw new System.NotImplementedException();

    public bool canAttackFlying => throw new System.NotImplementedException();

    public bool isFlying => throw new System.NotImplementedException();

    public bool isABuilding => throw new System.NotImplementedException();

    public bool isABuilder => throw new System.NotImplementedException();

    public bool canProduceUnits => throw new System.NotImplementedException();

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class RangedCalvarly : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.RangedCavalry;

    public int woodCost => 20;

    public int gemCost => 0;

    public int foodCost => 100;

    public int unitSize => 1;

    public int maxHealth => 150;

    public int armor => 0;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 21;

    public float damage => 6.5f;

    public float attackSpeed => 2;

    public float sightRange => 50;

    public float moveDelay => 0.5f;

    public TechType weaponType => TechType.BowDamage;

    public TechType armorType => TechType.MountArmor;

    public TechType healthType => TechType.MountHP;

    public TechType rangeType => TechType.BowRange;

    public bool isMovable => true;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => false;

    public bool isABuilding => false;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Wizard : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Wizard;

    public int woodCost => 15;

    public int gemCost => 150;

    public int foodCost => 40;

    public int unitSize => 1;

    public int maxHealth => 50;

    public int armor => 0;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 25;

    public float damage => 12;

    public float attackSpeed => 2;

    public float sightRange => 50;

    public float moveDelay => 0.5f;

    public TechType weaponType => TechType.MagicDamage;

    public TechType armorType => TechType.Armor;

    public TechType healthType => TechType.Nothing;

    public TechType rangeType => TechType.MagicDamage;

    public bool isMovable => true;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => false;

    public bool isABuilding => false;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class BlackSmith : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.BlackSmith;

    public int woodCost => 250;

    public int gemCost => 100;

    public int foodCost => 0;

    public int unitSize => 1;

    public int maxHealth => 1200;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 30;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Castle : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Castle;

    public int woodCost => 1000;

    public int gemCost => 0;

    public int foodCost => 0;

    public int unitSize => 1;

    public int maxHealth => 3000;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 40;

    public float damage => 6.5f;

    public float attackSpeed => 2;

    public float sightRange => 50;

    public float moveDelay => 0;

    public TechType weaponType => TechType.BowDamage;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.BowRange;

    public bool isMovable => false;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => true;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Farmland : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.FarmLand;

    public int woodCost => 100;

    public int gemCost => 0;

    public int foodCost => 0;

    public int unitSize => 1;

    public int maxHealth => 100;

    public int armor => 0;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 30;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Nothing;

    public TechType healthType => TechType.Nothing;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class House : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.House;

    public int woodCost => 100;

    public int gemCost => 0;

    public int foodCost => 0;

    public int unitSize => 1;

    public int maxHealth => 500;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 30;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Library : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Library;

    public int woodCost => 3000;

    public int gemCost => 200;

    public int foodCost => 0;

    public int unitSize => 1;

    public int maxHealth => 3000;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 30;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class PegasusStables : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.PegasusStables;

    public int woodCost => 300;

    public int gemCost => 50;

    public int foodCost => 200;

    public int unitSize => 1;

    public int maxHealth => 1800;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 0;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => true;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Stables : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Stables;

    public int woodCost => 250;

    public int gemCost => 0;

    public int foodCost => 200;

    public int unitSize => 1;

    public int maxHealth => 1500;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 30;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => true;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class Tower : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.Tower;

    public int woodCost => 200;

    public int gemCost => 0;

    public int foodCost => 0;

    public int unitSize => 0;

    public int maxHealth => 800;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 40;

    public float damage => 6.5f;

    public float attackSpeed => 2;

    public float sightRange => 50;

    public float moveDelay => 0;

    public TechType weaponType => TechType.BowDamage;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.BowRange;

    public bool isMovable => false;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => false;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class TrainingField : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.TrainingField;

    public int woodCost => 150;

    public int gemCost => 0;

    public int foodCost => 0;

    public int unitSize => 0;

    public int maxHealth => 1500;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 0;

    public float damage => 0;

    public float attackSpeed => 0;

    public float sightRange => 30;

    public float moveDelay => 0;

    public TechType weaponType => TechType.Nothing;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.Nothing;

    public bool isMovable => false;

    public bool targetsNearestEnemy => false;

    public bool canAttackFlying => false;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => true;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
public class WizardTower : IUnitTypeInformation
{
    public UnitType UnitType => UnitType.WizardTower;

    public int woodCost => 200;

    public int gemCost => 300;

    public int foodCost => 100;

    public int unitSize => 0;

    public int maxHealth => 1200;

    public int armor => 3;

    public int healthIncreaseIncrement => 1;

    public float attackRange => 40;

    public float damage => 24;

    public float attackSpeed => 4;

    public float sightRange => 50;

    public float moveDelay => 0;

    public TechType weaponType => TechType.MagicDamage;

    public TechType armorType => TechType.Structure;

    public TechType healthType => TechType.Structure;

    public TechType rangeType => TechType.MagicRange;

    public bool isMovable => false;

    public bool targetsNearestEnemy => true;

    public bool canAttackFlying => true;

    public bool isFlying => false;

    public bool isABuilding => true;

    public bool isABuilder => false;

    public bool canProduceUnits => true;

    public Sprite unitImage => throw new System.NotImplementedException();

    public Material buildingMaterial => throw new System.NotImplementedException();

    public Renderer coloredPart => throw new System.NotImplementedException();

    public List<UnitType> unitTypes => throw new System.NotImplementedException();

    public List<GameObject> unitGameObjects => throw new System.NotImplementedException();

    public List<UnitType> requiredStructures => throw new System.NotImplementedException();

    public AudioClip[] isSelectedAudio => throw new System.NotImplementedException();

    public AudioClip[] IncapableAudio => throw new System.NotImplementedException();

    public AudioClip[] ActionAudio => throw new System.NotImplementedException();
}
