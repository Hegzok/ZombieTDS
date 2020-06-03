using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject
{
    [SerializeField] [Range(0f, 20f)]
    private float movementSpeed;
    public float MovementSpeed => movementSpeed;

    [SerializeField]
    private int health;
    public int Health => health;

}
