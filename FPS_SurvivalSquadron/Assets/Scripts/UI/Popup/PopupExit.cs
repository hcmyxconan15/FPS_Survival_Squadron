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
        PopupPause popupPause = UIManager.Instance.GetExistPopup<PopupPause>();
        if(popupPause == null)
        {
            this.Hide();
        }
        else if(popupPause)
        {
            this.Hide();
            popupPause.Show(this.gameObject);
        }
    }
}
