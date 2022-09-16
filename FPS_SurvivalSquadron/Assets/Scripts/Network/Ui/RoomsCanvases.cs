using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    public CurrentRoomCanvas currentRoomCanvas;

    public CreateOrJoinRoomCanvas createOrJoinRoomCanvas;

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        currentRoomCanvas.FirstInittialize(this);
        createOrJoinRoomCanvas.FirstInittialize(this);
    }

}
