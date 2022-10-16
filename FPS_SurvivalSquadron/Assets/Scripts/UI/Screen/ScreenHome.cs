using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHome : BaseScreen
{
    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickPopupSetting()
    {
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ShowPopup<PopupSetting>();
        }
    }
}
