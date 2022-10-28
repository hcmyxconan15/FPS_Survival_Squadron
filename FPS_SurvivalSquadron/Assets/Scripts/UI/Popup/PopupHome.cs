using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : BasePopup
{
    PopupPause popupPause;
    ScreenHome screenHome;
    private void Start()
    {
        popupPause = UIManager.Instance.GetExistPopup<PopupPause>();
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

    public void OnClickYes(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();
        screenHome.Show(this.gameObject);
    }

    public void OnClickNo()
    {
        this.Hide();
        popupPause.Show(this.gameObject);
    }
}
