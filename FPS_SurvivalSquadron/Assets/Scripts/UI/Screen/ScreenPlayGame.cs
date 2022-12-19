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
    public GameObject go;
    public GameObject go1;
    void Start()
    {
        InstancePopupPause();
        InstancePopupHome();
    }

    // Update is called once per frame
    void Update()
    {
        OnButtonSetting();
        OnActiveSetting();
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
        if (SceneManager.GetActiveScene().name != "Room2")
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

    private void OnActiveSetting()
    {
        if (SceneManager.GetActiveScene().name == "Room1" || SceneManager.GetActiveScene().name == "Room2")
        {
            go.SetActive(false);
            go1.SetActive(false);
        }
        else
        {
            go.SetActive(true);
            go1.SetActive(true);
        }
    }


}
