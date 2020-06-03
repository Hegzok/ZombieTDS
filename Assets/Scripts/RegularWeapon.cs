using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Regular Weapon", menuName = ("Weapons/Regular Weapon"), order = 0)]
public class RegularWeapon : Weapon
{
    public override void Shoot(Transform hand)
    {
        base.Shoot(hand);
    }
}
