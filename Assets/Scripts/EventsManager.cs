using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsManager
{
    public static UnityAction<Weapon> OnWeaponPickUp;
    public static UnityAction<int> OnKeyPressedChangeUI;
    public static UnityAction<Weapon> OnKeyPressedChangeWeapon;
    public static UnityAction OnGameWon;
    public static UnityAction OnGameLost;

    public static void CallOnWeaponPickUp(Weapon weapon)
    {
        OnWeaponPickUp?.Invoke(weapon);
    }

    public static void CallOnKeyPressedChangeUI(int key)
    {
        OnKeyPressedChangeUI?.Invoke(key);
    }

    public static void CallOnKeyPressedChangeWeapon(Weapon weapon)
    {
        OnKeyPressedChangeWeapon?.Invoke(weapon);
    }

    public static void CallOnGameWon()
    {
        OnGameWon?.Invoke();
    }

    public static void CallOnGameLost()
    {
        OnGameLost.Invoke();
    }
}
