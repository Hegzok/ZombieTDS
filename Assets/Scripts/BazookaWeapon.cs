using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Explosive Weapon", menuName = ("Weapons/Explosive Weapon"), order = 0)]
public class BazookaWeapon : Weapon
{
    public override void Shoot(Transform hand)
    {
        base.Shoot(hand);
    }
}
