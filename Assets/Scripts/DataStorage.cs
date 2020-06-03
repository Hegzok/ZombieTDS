using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    [SerializeField] private MouseInfo mouseInfo;
    public static MouseInfo MouseInfo;

    [SerializeField] private UIManager uiManager;
    public static UIManager UIManager;

    [SerializeField] private Weapon emptyWeapon;
    public static Weapon EmptyWeapon;

    [SerializeField] private Player player;
    public static Player Player;

    private void Awake()
    {
        MouseInfo = mouseInfo;
        UIManager = uiManager;
        EmptyWeapon = emptyWeapon;
        Player = player;
    }

}
