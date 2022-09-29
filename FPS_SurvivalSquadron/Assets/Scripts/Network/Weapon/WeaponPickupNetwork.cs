using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponPickupNetwork : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon)
        {
            RayCastWeapon newWeapon = InstantiteWeapon.Instantite(prefab, Vector3.zero, Quaternion.identity).GetComponent<RayCastWeapon>();
            activeWeapon.Equip(newWeapon);
        }
    }
}
