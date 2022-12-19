using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyGame
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        float timeWaintConnect = 5;
        string gameVersion = "1";
        [SerializeField]
        private byte maxPlayersPerRoom = 4;
        public GameObject UIJoin;
        private void Awake()
        {
            ConnectGame();
        }
        public void ConnectGame()
        {
            StartCoroutine(Connect());
        }
        #region Connect and disconnect
        public IEnumerator Connect()
        {
            for (int i = 0; i < 15; i++)
            {
                if (!PhotonNetwork.IsConnected)
                {
                    PhotonNetwork.GameVersion = gameVersion;
                    PhotonNetwork.AutomaticallySyncScene = true;
                    PhotonNetwork.SerializationRate = 5;
                    PhotonNetwork.ConnectUsingSettings();
                    yield return new WaitForSeconds(timeWaintConnect);
                }
                else
                {

                    break;
                }
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
            Debug.Log("Khong the ket noi thanh cong: " + cause);
        }
        public override void OnJoinedLobby()
        {
            
        }
    }
}
