using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSelect : BasePopup
{
    ScreenHome screenHome;
    ScreenPlayGame screenPlayGame;

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
        //InstanceScreenPlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstanceScreenPlayGame()
    {
        UIManager.Instance.ShowScreen<ScreenPlayGame>();
        screenPlayGame = UIManager.Instance.GetExistScreen<ScreenPlayGame>();
        if (screenPlayGame != null)
        {
            screenPlayGame.Hide();
        }
    }


    public void OnClickLoadScreenTutourial(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();
        //screenPlayGame.Show(this.gameObject);
        UIManager.Instance.ShowScreen<ScreenPlayGame>();
    }

    public void OnClickLoadScreenSingle(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();
        //screenPlayGame.Show(this.gameObject);
        UIManager.Instance.ShowScreen<ScreenPlayGame>();
    }

    public void OnClickLoadScreenMultiPlayer(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();
        //screenPlayGame.Show(this.gameObject);
        UIManager.Instance.ShowScreen<ScreenPlayGame>();
    }

    public void OnClickBack()
    {
        this.Hide();
        screenHome.Show(this.gameObject);
    }


}
