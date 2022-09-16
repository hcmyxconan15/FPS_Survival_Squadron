using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Transform content;

    [SerializeField] 
    PlayerListing playerListing;

    [SerializeField] Text _readyUpText;
    List<PlayerListing> playerListings = new List<PlayerListing>();
    private bool _ready;

    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayer();
        SetReadyUp(false);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        RemovePlayerListing();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = playerListings.FindIndex(x => x.player == otherPlayer);
        if(index!=-1)
        {
            Destroy(playerListings[index].gameObject);
            playerListings.RemoveAt(index);
        }
    }

    private void GetCurrentRoomPlayer()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void RemovePlayerListing()
    {
        playerListings.ForEach(x => Destroy(x.gameObject));
        playerListings.Clear();
    }

    private void AddPlayerListing(Player player)
    {
        PlayerListing _playerListing = Instantiate(playerListing, content);
        if (playerListing != null)
        {
            playerListings.Add(_playerListing);
            _playerListing.SetPlayerInfo(player);
        }
    }

    public void SetReadyUp(bool state)
    {
        _ready = state;
        if(_ready)
        {
            _readyUpText.text = "R";
        }
        else
        {
            _readyUpText.text = "N";
        }
    }

    public void Onlick_StartButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < playerListings.Count; i++)
            {
                if (playerListings[i].player != PhotonNetwork.LocalPlayer)
                {
                    if (!playerListings[i].Ready)
                    {
                        return;
                    }
                }
            }
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void Onlick_ReadyUp()
    {
        if(!PhotonNetwork.IsMasterClient)
        { 
            SetReadyUp(!_ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player _player, bool ready)
    {
        int index = playerListings.FindIndex(x => x.player == _player);
        if (index != -1)
        {
            playerListings[index].Ready = ready;
        }
    }
}
