using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] Transform transformParrent;
    private List<Transform> transforms;
    private void Awake()
    {
        transforms = transformParrent.GetComponentsInChildren<Transform>().ToListPooled();
    }
    private void Start()
    {
        Instantite();
    }
    
    private void Instantite()
    {
        GameObject go = PhotonNetwork.Instantiate("Prefab/Player", RamdomPostion(), Quaternion.identity);
        go.tag = "Enemy";

    }
    Vector3 RamdomPostion()
    {
        int ran = Random.RandomRange(0, transforms.Count);
        return transforms[ran].position;
    }
}
