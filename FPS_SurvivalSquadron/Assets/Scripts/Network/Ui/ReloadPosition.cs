using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPosition : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    public void Onclick()
    {
        player.gameObject.transform.position = Vector3.zero;
    }
}
