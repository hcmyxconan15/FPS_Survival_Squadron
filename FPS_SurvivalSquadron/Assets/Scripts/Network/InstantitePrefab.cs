using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    
    private void Start()
    {
        Instantite();
    }
    
    private void Instantite()
    {
       PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
       
        
    }
}
