using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestObserver : MonoBehaviour
{
    public Text countText;
    int Count = 0;

    private void Start()
    {
        if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_COUNT_BULLET, OnListenUpdateCountText);
        }
    }

    private void OnListenUpdateCountText(object v)
    {
        if(v != null)
        {
            if(v is int value)
            {
                Count += value;
                countText.text = "Count: " + Count;
            }
        }
    }
}
