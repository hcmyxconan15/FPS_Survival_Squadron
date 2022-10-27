using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPlayGame : BaseScreen
{
    PopupPause popupPause;

    // Start is called before the first frame update
    void Start()
    {
        InstancePopupPause();
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

    private void InstancePopupPause()
    {
        UIManager.Instance.ShowPopup<PopupPause>();
        popupPause = UIManager.Instance.GetExistPopup<PopupPause>();
        if (popupPause != null)
        {
            popupPause.Hide();
        }
    }

    public void OnClickPopupPause()
    {
        Time.timeScale = 0;
        popupPause.Show(this.gameObject);
        this.Hide();
    }
}
