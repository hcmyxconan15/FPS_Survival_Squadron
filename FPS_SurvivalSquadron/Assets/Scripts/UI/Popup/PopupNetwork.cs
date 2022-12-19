using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MyGame;

public class PopupNetwork : BasePopup
{
    public Launcher launcher =>GetComponent<Launcher>();

    public void Onlick_Quit()
    {
        Photon.Pun.PhotonNetwork.Disconnect();
        base.Hide();
    }
    public override void Show(object data)
    {
        launcher.ConnectGame();
        base.Show(data);
    }

}
