using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform crossTarget;

    private void Start()
    {
        Instantite();
    }
    
    private void Instantite()
    {
       GameObject go =  PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
       go.GetComponent<ActiveWeapon>().crossHairTarget = crossTarget;
    }
}
