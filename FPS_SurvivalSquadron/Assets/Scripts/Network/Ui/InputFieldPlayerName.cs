using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InputFieldPlayerName : MonoBehaviour
{
    InputField inputField => GetComponent<InputField>();
    private void Awake()
    {
        GetName();
    }

    public void SetName(string value)
    {
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString("Player", value);
    }

    private void GetName()
    {
        if(PlayerPrefs.HasKey("Player"))
        {
            string name = PlayerPrefs.GetString("Player");
            inputField.text = name;
            PhotonNetwork.NickName = name;
        }
    }
}
