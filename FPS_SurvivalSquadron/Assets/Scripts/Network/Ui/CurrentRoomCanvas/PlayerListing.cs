using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Text text;

    public Player player;

    public bool Ready = false;

    public void SetPlayerInfo(Player _player)
    {
        this.player = _player;
        int? result = -1;
        if (_player.CustomProperties.ContainsKey("Random"))
        {
            result = (int)_player.CustomProperties["Random"];
        }
        text.text = result.ToString()  + ", "+  _player.NickName;
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(player == targetPlayer)
        {
            int result = (int)changedProps["Random"];
            text.text = result.ToString() + ", " + targetPlayer.NickName;
        }
    }

}
