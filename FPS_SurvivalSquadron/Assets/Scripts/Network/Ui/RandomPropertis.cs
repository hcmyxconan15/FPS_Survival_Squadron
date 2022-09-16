using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RandomPropertis : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text text;
    ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();  
    public void SetRamdomProperties()
    {
        int result = Random.Range(0, 100);
        PlayerPrefs.SetInt("Properties", result);
        customProperties["Random"] = result;
        PhotonNetwork.SetPlayerCustomProperties(customProperties);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["Random"]);
        text.text = result.ToString();
    }
    public override void OnJoinedLobby()
    {
        GetProperties();
        
    }
    public void Onlick_Random()
    {
        SetRamdomProperties();
    }
    public void GetProperties()
    {
        int result = PlayerPrefs.GetInt("Properties");
        customProperties["Ramdom"] = result;
        PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        text.text = result.ToString();
    }
    public void Onlick_RamdomUpdate()
    {
        int result = Random.Range(0, 100);
        customProperties["Random"] = result;
        text.text = result.ToString();
    }
}
