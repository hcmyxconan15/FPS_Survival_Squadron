using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadCastEvent : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (ListenerManager.HasInstance)
            {
                int sendValue = 3;
                ListenerManager.Instance.BroadCast(ListenType.UPDATE_COUNT_BULLET, sendValue);
            }
        }
    }
}
