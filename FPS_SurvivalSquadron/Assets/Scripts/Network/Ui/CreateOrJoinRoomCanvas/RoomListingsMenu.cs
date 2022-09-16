using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListing roomListing;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private RoomsCanvases roomCanvases;

    private List<RoomListing> roomListings = new List<RoomListing>();
   
    public override void OnJoinedRoom()
    {
        //roomListings.Clear();
        roomCanvases.currentRoomCanvas.Show();
        Debug.Log("tham gia room");
        roomCanvases.createOrJoinRoomCanvas.gameObject.SetActive(false);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if(info.RemovedFromList)
            {
                int index = roomListings.FindIndex(x => x.roomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(roomListings[index].gameObject);
                    roomListings.RemoveAt(index);
                }
            }
            else
            {

                int index = roomListings.FindIndex(x => x.roomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = Instantiate(roomListing, content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        roomListings.Add(listing);
                    }
                }
            }           
        }
    }

}
