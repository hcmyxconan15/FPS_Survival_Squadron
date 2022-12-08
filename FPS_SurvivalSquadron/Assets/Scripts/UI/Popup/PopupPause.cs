using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopupPause : BasePopup
{
    PopupSetting popupSetting;
    ScreenPlayGame screenPlayGame;
    PopupExit popupExit;
    PopupHome popupHome;

    // Start is called before the first frame update
    void Start()
    {
        popupSetting = UIManager.Instance.GetExistPopup<PopupSetting>();
        screenPlayGame = UIManager.Instance.GetExistScreen<ScreenPlayGame>();
        popupExit = UIManager.Instance.GetExistPopup<PopupExit>();
        popupHome = UIManager.Instance.GetExistPopup<PopupHome>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        this.Hide();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        screenPlayGame.Show(this.gameObject);
    }

    public void OnClickHome()
    {
        this.Hide();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        popupHome.Show(this.gameObject);
    }
    public void OnClickPopupSetting()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        popupSetting.Show(this.gameObject);
        this.Hide();
    }

    public void OnClickQuitApplication()
    {
        this.Hide();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        popupExit.Show(this.gameObject);
    }
}

