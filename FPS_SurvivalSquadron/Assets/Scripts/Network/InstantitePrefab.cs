using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] Transform crossTarget;
    [SerializeField] AmmoWidget ammoWidget;
    [SerializeField] Transform playerCamera;
    [SerializeField] LoadMap loadMap;
    private void Start()
    {
        Instantite();
        InstantiteEnemy();
    }
    
    private void Instantite()
    {
       GameObject go =  PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        ActiveWeapon activeWeapon = go.GetComponent<ActiveWeapon>();
        activeWeapon.crossHairTarget = crossTarget;
        activeWeapon.ammoWidget = ammoWidget;
        go.GetComponent<PlayerAmingNetwork>().CameraLookAt = playerCamera;
       go.GetComponent<ReloadWeapon>().ammoWidget = ammoWidget;
       
    }
    private void InstantiteEnemy()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            loadMap.InstantiateEnemy("Map_1");
        }
    }
}
