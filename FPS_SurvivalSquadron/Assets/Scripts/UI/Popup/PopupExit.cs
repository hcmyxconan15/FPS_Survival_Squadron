using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupExit : BasePopup
{
    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickYes()
    {
        Application.Quit();
    }

    public void OnClickNo()
    {
        this.Hide();
    }
}
