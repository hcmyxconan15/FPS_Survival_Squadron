using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenHome : BaseScreen
{
    PopupSetting popupSetting;
    PopupAbout popupAbout;

    private void Start()
    {
        if (UIManager.HasInstance)
        {
            InstancePopupSetting();
            InstancePopupAbout();
        }
    }

    private void InstancePopupSetting()
    {
        UIManager.Instance.ShowPopup<PopupSetting>();
        popupSetting = UIManager.Instance.GetExistPopup<PopupSetting>();
        if (popupSetting != null)
        {
            popupSetting.Hide();
        }
    }

    private void InstancePopupAbout()
    {
        UIManager.Instance.ShowPopup<PopupAbout>();
        popupAbout = UIManager.Instance.GetExistPopup<PopupAbout>();
        if (popupAbout != null)
        {
            popupAbout.Hide();
        }
    }

 
    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickLoadScreen(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnClickPopupAbout()
    {
        popupAbout.Show(this.gameObject);
        if (popupSetting != null)
        {
            popupSetting.Hide();
        }
    }

    public void OnClickPopupSetting()
    {
        popupSetting.Show(this.gameObject);
        if (popupAbout != null)
        {
            popupAbout.Hide();
        }
    }

    public void OnClickQuitApplication()
    {
        Application.Quit();
    }
}
