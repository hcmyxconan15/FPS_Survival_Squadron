using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupHome : BasePopup
{
    PopupPause popupPause;
    ScreenHome screenHome;
    ScreenPlayGame screenPlayGame;
    private void Start()
    {
        popupPause = UIManager.Instance.GetExistPopup<PopupPause>();
        screenHome = UIManager.Instance.GetExistScreen<ScreenHome>();
        screenPlayGame = UIManager.Instance.GetExistScreen<ScreenPlayGame>();
    }
    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public void OnClickYes(string name)
    {
        SceneManager.LoadScene(name);
        if(Photon.Pun.PhotonNetwork.IsConnected)
        {
            Photon.Pun.PhotonNetwork.Disconnect();
        }
        this.Hide();
        screenPlayGame.Hide();
        popupPause.Hide();
        screenHome.Show(this.gameObject);
        Time.timeScale = 1;
        if(SceneManager.GetActiveScene().name != "UI")
        {
            UIManager.Instance.GetExistNotify<NotifyVictory>().Hide();
        }
        ScreenPlayGame.countEnemy = 0;
        ListenerManager.Instance.BroadCast(ListenType.UPDATE_COUNT_ENEMY, ScreenPlayGame.countEnemy);
        ListenerManager.Instance.BroadCast(ListenType.UPDATE_HP_PLAYER, PlayerPrefs.GetFloat(CONSTANT.PP_MAXHPPLAYER));

    }

    public void OnClickNo()
    {
        this.Hide();
        popupPause.Show(this.gameObject);
    }
}
