using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class SetPlayerIsMine : MonoBehaviour
{
    Photon.Pun.PhotonView pv => GetComponent<Photon.Pun.PhotonView>();


    private void Awake()
    {
        if (pv.IsMine)
        {
            GetComponent<vShooterMeleeInput>().enabled = true;
        }
    }
}
