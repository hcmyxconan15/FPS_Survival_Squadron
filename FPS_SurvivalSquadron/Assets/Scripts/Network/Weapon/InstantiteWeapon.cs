using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiteWeapon
{
    public static GameObject Instantite(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Photon.Pun.PhotonNetwork.Instantiate(prefab.name, position, rotation);
    }
}
