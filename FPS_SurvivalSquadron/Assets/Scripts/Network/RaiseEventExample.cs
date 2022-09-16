using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class RaiseEventExample : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private const byte COLOR_CHANGE_EVENT = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReced;
    }
    private void OnEnable()
    {
        
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReced;
    }

    private void NetworkingClient_EventReced(EventData obj)
    {
        Debug.Log("Test");
        if(obj.Code == COLOR_CHANGE_EVENT)
        {
            object[] datas = obj.CustomData as object[];
            float r = (float)datas[0];
            float b = (float)datas[1];
            float g = (float)datas[2];
            spriteRenderer.color = new Color(r, b, g, 1f);

        }
    }
    private void Test(EventData obj)
    {
        Debug.Log("test3");
    }
    private void ChangeColor()
    {
        float r = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);

        spriteRenderer.color = new Color(r, b, g, 1f);

        object[] datas = new object[] { r, b, g, };

        PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }
}
