using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public RoomInfo roomInfo;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;
        text.text = roomInfo.Name;
    }
    public void OnlickButton()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }

}
