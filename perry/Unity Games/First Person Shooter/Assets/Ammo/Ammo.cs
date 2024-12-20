using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public void ReduceAmountOfAmmo(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoAmount--;
    }

    public int GetAmountOfAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    public void CollectAmmo(AmmoType ammoType, int amount)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoAmount+= amount;
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if(slot.ammoType == ammoType) return slot;

        }
        return null;
    }

}
