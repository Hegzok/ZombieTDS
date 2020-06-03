using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Empty Weapon", menuName = ("Weapons/Empty Weapon"), order = 1)]
public class EmptyWeapon : Weapon
{
    public override void Shoot(Transform hand)
    {
        Debug.LogFormat("Cant shoot with {0}", WeaponName);
    }
}
