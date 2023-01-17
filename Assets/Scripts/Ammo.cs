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
        public int ammoAmoumt;
    }
    

    public int GetCurrentAmmo(AmmoType ammoType){
        return GetAmmoSlot(ammoType).ammoAmoumt;
    }
    public void ReduceCurrentAmmo(AmmoType ammoType) {
         GetAmmoSlot(ammoType).ammoAmoumt--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmoumt+= ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
