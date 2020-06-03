using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponToPickUp : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon => weapon;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            EventsManager.CallOnWeaponPickUp(weapon);
            Destroy(this.gameObject);
        }
    }
}
