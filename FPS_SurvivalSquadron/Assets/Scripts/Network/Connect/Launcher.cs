using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyGame
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        string gameVersion = "1";
        [SerializeField]
        private byte maxPlayersPerRoom = 4;
        void Awake()
        {
            
            Connect();
        }
        private void Start()
        {
            
        }
        #region Connect and disconnect
        public void Connect()
        {
            if(!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.SerializationRate = 5;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        #endregion
        public override void OnConnectedToMaster()
        {
            if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
        }
        public override void OnConnected()
        {
            Debug.Log("Hello to room");
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Da nga ket noi: " + cause);
        }
        public override void OnJoinedLobby()
        {
            Debug.Log("Join lobby");
        }
    }
}
