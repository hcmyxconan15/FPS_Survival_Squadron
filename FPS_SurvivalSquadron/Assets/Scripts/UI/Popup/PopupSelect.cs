using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSelect : BasePopup
{
    ScreenPlayGame screenPlayGame;
    ScreenHome screenHome;
    bool isloaded = false;
    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public override void Init()
    {
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        screenHome = UIManager.Instance.GetExistScreen<ScreenHome>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        UIManager.Instance.ShowNotify<NotifyLoadingPlayGame>();
        NotifyLoadingPlayGame scr = UIManager.Instance.GetExistNotify<NotifyLoadingPlayGame>();
        if (scr != null && isloaded == false)
        {
            UIManager.Instance.ShowScreen<ScreenPlayGame>();
            screenPlayGame = UIManager.Instance.GetExistScreen<ScreenPlayGame>();
            isloaded = true;
        }
        else if (scr != null && isloaded)
        {
            scr.gameObject.SetActive(true);
            screenPlayGame.Show(this.gameObject);
        }
        screenHome.Hide();
    }

    public void OnClickLoadScreenTutourial(string name)
    {
        this.Hide();
        LoadGame();
        SceneManager.LoadScene(name);
    }

    public void OnClickLoadScreenSingle(string name)
    {
        this.Hide();
        LoadGame();
        SceneManager.LoadScene(name);
    }

    public void OnClickLoadScreenMultiPlayer(string name)
    {
        //this.Hide();
        //LoadGame();
        //SceneManager.LoadScene(name);
        UIManager.Instance.ShowPopup<PopupNetwork>();
        var popup = UIManager.Instance.GetExistPopup<PopupNetwork>();
        popup.transform.localPosition = new Vector3(-980, -520, 0);
    }

    public void OnClickBack()
    {
        this.Hide();
        screenHome.Show(this.gameObject);
    }
}
