using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerIsMine : MonoBehaviour
{
    Photon.Pun.PhotonView pv => GetComponent<Photon.Pun.PhotonView>();

    public bool PlayerIsMine = false ;


    private void Awake()
    {
        if (pv.IsMine)
        {
            PlayerIsMine = true;
        }
        else
        {
            PlayerIsMine = false;
        }
    }
}
