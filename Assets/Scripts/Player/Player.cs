using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private Transform shootingPoint;

    [SerializeField] public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        HandleEvents(true);
        EventsManager.CallOnKeyPressedChangeUI(1);

        if (currentWeapon != null)
        {
            PickUpWeapon(currentWeapon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();

        if (Input.GetMouseButton(0) && currentWeapon != null)
        {
            Shoot();
        }
    }

    private void OnDisable()
    {
        HandleEvents(false);
    }

    private void HandleEvents(bool switcher)
    {
        if (switcher)
        {
            EventsManager.OnWeaponPickUp += PickUpWeapon;
            EventsManager.OnKeyPressedChangeWeapon += PickUpWeapon;
        }
        else
        {
            EventsManager.OnWeaponPickUp -= PickUpWeapon;
            EventsManager.OnKeyPressedChangeWeapon -= PickUpWeapon;
        }
    }

    private void Shoot()
    {
        if (Time.time > weaponInfo.lastTimeShooted + weaponInfo.shootRatio)
        {
            currentWeapon.Shoot(shootingPoint);
            weaponInfo.lastTimeShooted = Time.time;
        }
    }

    public void PickUpWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        weaponInfo.weaponName = weapon.WeaponName;
        weaponInfo.shootRatio = weapon.ShootRatio;
    }

    //private void EquipWeapon()
    //{
    //    weaponInfo.weaponPrefab = Instantiate(weaponInfo.weaponPrefab);
    //    Destroy(weaponInfo.weaponPrefab.GetComponent<WeaponToPickUp>()); // Destroy script so it doesnt pick itself over and over Delete when interract button is done
    //    weaponInfo.weaponPrefab.transform.parent = this.transform;
    //    weaponInfo.weaponPrefab.transform.localPosition = hand.localPosition;
    //}

    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventsManager.CallOnKeyPressedChangeUI(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventsManager.CallOnKeyPressedChangeUI(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventsManager.CallOnKeyPressedChangeUI(3);
        }
    }
}

#region ---------- Structs -----------
[System.Serializable]
public struct WeaponInfo
{
    public string weaponName;
    public float shootRatio;

    public float lastTimeShooted; // delete
}
#endregion ---------------------------
