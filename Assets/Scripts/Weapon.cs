using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = ("Weapons/Weapon"), order = 1)]
public class Weapon : ScriptableObject
{
    [SerializeField] protected GameObject weaponPrefab;
    public GameObject WeaponPrefab => weaponPrefab;

    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;

    [SerializeField] protected string weaponName;
    public string WeaponName => weaponName;

    [SerializeField] protected int damage;
    public int Damage => damage;

    [SerializeField] protected float shootRatio;
    public float ShootRatio => shootRatio;

    [SerializeField] protected Sprite weaponIcon;
    public Sprite WeaponIcon => weaponIcon;

    public virtual void Shoot(Transform hand)
    {
        Bullet bulletPrefab = Instantiate(bullet, hand.transform.position, Quaternion.identity);

        bulletPrefab.damage = Damage;
    }


}
