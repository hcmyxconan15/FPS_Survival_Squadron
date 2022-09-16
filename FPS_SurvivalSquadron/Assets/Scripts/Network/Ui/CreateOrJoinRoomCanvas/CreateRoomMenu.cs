using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text roomName;

    [SerializeField]
    RoomsCanvases roomCanvases;
    public void OnLick_CreateRoom()
    {
        if(!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName.text, options, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        roomCanvases.currentRoomCanvas.Show();
        roomCanvases.createOrJoinRoomCanvas.gameObject.SetActive(false);
    }
    public override void OnJoinedRoom()
    {
        roomCanvases.currentRoomCanvas.Show();
        roomCanvases.createOrJoinRoomCanvas.gameObject.SetActive(false);
    }

}
