using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Photon.Pun;

public class SetPlayerIsMine : MonoBehaviour
{
    Photon.Pun.PhotonView pv => GetComponent<Photon.Pun.PhotonView>();
    vThirdPersonController go;
    bool dead = false;

    private void Awake()
    {
        if (!pv.IsMine)
        {
            GetComponent<vShooterMeleeInput>().enabled = false;
        }
        go = GetComponent<vThirdPersonController>();
        dead = false;
    }
    private void Update()
    {
        if(go.isDead && !dead)
        {
            if (gameObject.tag == "TeamA")
            {

                pv.RPC("PointB", RpcTarget.All);
                Debug.Log(CheckPoints.PointTeamB);
            }
            else if (gameObject.tag == "TeamB")
            {
                pv.RPC("PointA", RpcTarget.All);
                Debug.Log(CheckPoints.PointTeamA);
            }
            dead = true;
        }
    }
    [PunRPC]
    public void PointA()
    {
        CheckPoints.PointTeamA++;
    }
    [PunRPC]
    public void PointB()
    {
        CheckPoints.PointTeamB++;
    }
}
