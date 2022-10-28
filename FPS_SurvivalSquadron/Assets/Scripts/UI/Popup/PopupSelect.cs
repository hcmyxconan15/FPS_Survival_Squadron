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

    private void LoadGame()
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
            scr.time = scr.defautTime;
            scr.gameObject.SetActive(true);
            screenPlayGame.Show(this.gameObject);
        }
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
        this.Hide();
        LoadGame();
        SceneManager.LoadScene(name);
    }

    public void OnClickBack()
    {
        this.Hide();
        screenHome.Show(this.gameObject);
    }
}
