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
    }
    
    private void Instantite()
    {
        GameObject go = PhotonNetwork.Instantiate("Prefab/Player", Vector3.zero, Quaternion.identity);
        

    }
}
