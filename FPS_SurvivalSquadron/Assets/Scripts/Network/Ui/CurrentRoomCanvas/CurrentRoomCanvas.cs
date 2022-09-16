using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    private RoomsCanvases roomsCanvases;

    public void FirstInittialize(RoomsCanvases canvases)
    {
        roomsCanvases = canvases;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
