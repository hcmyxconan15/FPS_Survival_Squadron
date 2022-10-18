using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void OnClickLoadScreen(string name)
    {
        SceneManager.LoadScene(name);
    }
}
