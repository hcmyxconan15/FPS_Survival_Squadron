using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenHome : BaseScreen
{
    PopupSetting popupSetting;
    PopupAbout popupAbout;
    PopupSelect popupSelect;
    PopupExit popupExit;

    private void Start()
    {
        if (UIManager.HasInstance)
        {
            InstancePopupSetting();
            InstancePopupAbout();
            InstancePopupSelect();
            InstancePopupExit();
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
    
    private void InstancePopupSelect()
    {
        UIManager.Instance.ShowPopup<PopupSelect>();
        popupSelect = UIManager.Instance.GetExistPopup<PopupSelect>();
        if (popupSelect != null)
        {
            popupSelect.Hide();
        }
    }    
    
    private void InstancePopupExit()
    {
        UIManager.Instance.ShowPopup<PopupExit>();
        popupExit = UIManager.Instance.GetExistPopup<PopupExit>();
        if (popupExit != null)
        {
            popupExit.Hide();
        }
    }

 
    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickSelectScreen()
    {
        popupSelect.Show(this.gameObject);
        popupAbout.Hide();
        popupSetting.Hide();
        popupExit.Hide();
        this.Hide();
    }

    public void OnClickPopupAbout()
    {
        popupAbout.Show(this.gameObject);
        popupSetting.Hide();
        popupSelect.Hide();
        popupExit.Hide();
    }

    public void OnClickPopupSetting()
    {
        popupSetting.Show(this.gameObject);
        popupAbout.Hide();
        popupSelect.Hide();
        popupExit.Hide();
    }

    public void OnClickQuitApplication()
    {
        popupExit.Show(this.gameObject);
        popupSetting.Hide();
        popupAbout.Hide();
        popupSelect.Hide();
    }
}
