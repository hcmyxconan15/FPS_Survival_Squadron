using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Invector.vCharacterController;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] Transform transformParrent;
    private List<Transform> transforms;
    private GameObject goMine;
    public float time;

    private void Awake()
    {
        transforms = transformParrent.GetComponentsInChildren<Transform>().ToListPooled();
    }
    private void Start()
    {
        Instantite();
        bool isdead = false;
    }
    
    private void Instantite()
    {
        GameObject go = PhotonNetwork.Instantiate("Prefab/Player", RamdomPostion(), Quaternion.identity);
        go.tag = "Enemy";
        if(go.GetComponent<PhotonView>().IsMine)
        {
            goMine = go;
        }

    }
    bool isdead;
    private void Update()
    {
        if(goMine != null)
        {
            if(goMine.GetComponent<vThirdPersonController>().isDead && !isdead)
            {
                isdead = true;
                StartCoroutine(Revirse());

            }
        }
        
    }
    Vector3 RamdomPostion()
    {
        int ran = Random.RandomRange(0, transforms.Count);
        return transforms[ran].position;
    }
    IEnumerator Revirse()
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(goMine);
        Instantite();
        isdead = false;
    }
}
