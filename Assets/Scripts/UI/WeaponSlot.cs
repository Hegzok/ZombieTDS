using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    private Weapon Weapon => currentWeapon;

    [SerializeField] private Weapon emptyWeapon;

    [SerializeField] private Image icon;
    [SerializeField] private Image activeSlotImage;

    [SerializeField] private int id;

    [SerializeField] private bool currentSlot = false;
    public bool CurrentSlot => currentSlot;

    private void Awake()
    {
        icon = GetComponent<Image>();

        HandleEvents(true);
    }

    private void Start()
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
            EventsManager.OnKeyPressedChangeUI += ActivateWeaponSlot;
        }
        else
        {
            EventsManager.OnKeyPressedChangeUI -= ActivateWeaponSlot;
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        icon.sprite = weapon.WeaponIcon;

        if (currentSlot != true)
        {
            ActivateWeaponSlot(this.id);
        }
    }

    public void SwapWeapon(Weapon weapon)
    {
        if (currentWeapon != null && currentSlot)
        {
            currentWeapon = weapon;
            icon.sprite = weapon.WeaponIcon;
        }
    }

    public void ActivateWeaponSlot(int key)
    {
        emptyWeapon = DataStorage.EmptyWeapon;
        DeactivateWeaponSlot();

        if (id == key)
        {
            currentSlot = true;
            activeSlotImage.enabled = true;

            if (currentWeapon != null)
            {
                EventsManager.CallOnKeyPressedChangeWeapon(currentWeapon);
            }
            else
            {
                EventsManager.CallOnKeyPressedChangeWeapon(emptyWeapon);
            }
        }
    }

    public void DeactivateWeaponSlot()
    {
        currentSlot = false;
        activeSlotImage.enabled = false;
    }

    public bool ReturnEmptySlot()
    {
        if (currentWeapon == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
