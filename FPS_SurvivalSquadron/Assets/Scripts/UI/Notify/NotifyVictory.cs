using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotifyVictory : BaseNotify
{
    ScreenHome screenHome;
    private void Start()
    {
        screenHome = UIManager.Instance.GetExistScreen<ScreenHome>();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickHome(string name)
    {
        UIManager.Instance.GetExistPopup<PopupHome>().OnClickYes("UI");
        this.Hide();
    }

}
