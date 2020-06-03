using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private WeaponSlot[] weaponSlots;
    [SerializeField] private bool haveEmptySlots = false; // Delete analyze and try to remove since its not necessary i think

    // Start is called before the first frame update
    void Start()
    {
        HandleEvents(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        HandleEvents(false);
    }

    private void HandleEvents(bool switcher)
    {
        if (switcher)
        {
            EventsManager.OnWeaponPickUp += EquipWeapon;
        }
        else
        {
            EventsManager.OnWeaponPickUp -= EquipWeapon;
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        CheckForEmptySlots();

        if (haveEmptySlots)
        {          
            foreach (WeaponSlot weaponSlot in weaponSlots)
            {
                weaponSlot.DeactivateWeaponSlot();

                if (weaponSlot.ReturnEmptySlot())
                {
                    weaponSlot?.EquipWeapon(weapon);
                    break;
                }
            }
        }
        else
        {
            foreach (WeaponSlot weaponSlot in weaponSlots)
            {
                weaponSlot?.SwapWeapon(weapon);
            }
        }
    }

    private void CheckForEmptySlots()
    {
        foreach (WeaponSlot weaponSlot in weaponSlots)
        {
            if (weaponSlot.ReturnEmptySlot())
            {
                haveEmptySlots = true;
            }
            else
            {
                haveEmptySlots = false;
            }
        }
    }



}
