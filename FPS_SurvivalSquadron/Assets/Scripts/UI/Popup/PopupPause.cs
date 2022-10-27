using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPause : BasePopup
{
    PopupSetting popupSetting;
    ScreenPlayGame screenPlayGame;
    PopupExit popupExit;

    // Start is called before the first frame update
    void Start()
    {
        popupSetting = UIManager.Instance.GetExistPopup<PopupSetting>();
        screenPlayGame = UIManager.Instance.GetExistScreen<ScreenPlayGame>();
        popupExit = UIManager.Instance.GetExistPopup<PopupExit>();

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

    public void OnClickPopupSetting()
    {
        popupSetting.Show(this.gameObject);
        this.Hide();
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        this.Hide();
        screenPlayGame.Show(this.gameObject);
    }

    public void OnClickQuitApplication()
    {
        popupExit.Show(this.gameObject);
        this.Hide();
    }
}

