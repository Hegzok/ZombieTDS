using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Monster", menuName ="Monsters/Monster")]
public class MonsterStats : ScriptableObject
{
    [SerializeField] private string monsterName;
    public string MonsterName => monsterName;

    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;

    [SerializeField] private float movementSpeed;
    public float MovementSpeed => movementSpeed;

    [SerializeField] private int damage;
    public int Damage => damage;

    [SerializeField] private float attackSpeed;
    public float AttackSpeed => attackSpeed;
}
