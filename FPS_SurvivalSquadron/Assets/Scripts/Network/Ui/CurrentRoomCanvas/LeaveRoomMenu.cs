using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LeaveRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    RoomsCanvases roomCanvases;

    public void Onlick_LeaveRoom()
    {
        if(!PhotonNetwork.IsConnected)
        {
            return;
        }
        PhotonNetwork.LeaveRoom();
    }
    
    public override void OnLeftRoom()
    {
        roomCanvases.currentRoomCanvas.Hide();
        roomCanvases.createOrJoinRoomCanvas.Show();
    }

}
