using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenPlayGame : BaseScreen
{
    PopupPause popupPause;
    public PopupPause PopupPause => popupPause;
    public static int countEnemy = 0;
    public bool isDone = false;
    // Start is called before the first frame update
    void Start()
    {
        InstancePopupPause();
        InstancePopupHome();
    }

    // Update is called once per frame
    void Update()
    {
        OnButtonSetting();
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

    private void InstancePopupHome()
    {
        UIManager.Instance.ShowPopup<PopupHome>();
        PopupHome popupHome = UIManager.Instance.GetExistPopup<PopupHome>();
        if (popupHome != null)
        {
            popupHome.Hide();
        }
    }    
    

    public void OnClickPopupPause()
    {
        Time.timeScale = 0;
        popupPause.Show(this.gameObject);
        this.Hide();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnButtonSetting()
    {
        if (SceneManager.GetActiveScene().name != "UI" && isDone == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnClickPopupPause();
            }
        }
    }
}
