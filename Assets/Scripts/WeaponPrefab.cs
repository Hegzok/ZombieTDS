using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefab : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon => weapon;

    [SerializeField] private GameObject GFX;

    // Start is called before the first frame update
    void Start()
    {
        EventsManager.OnKeyPressedChangeWeapon += Activate;
        EventsManager.OnWeaponPickUp += Activate;
    }

    private void OnDestroy()
    {
        EventsManager.OnKeyPressedChangeWeapon -= Activate;
        EventsManager.OnWeaponPickUp -= Activate;
    }

    public void Activate(Weapon weapon)
    {
        if (this.weapon == weapon)
        {
            GFX.SetActive(true);
        }
        else
        {
            GFX.SetActive(false);
        }
    }
}
