using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthPlayerObsever : MonoBehaviour
{
    public Text countEnemy;
    public Image healthBar;
    private float maxHp;
    NotifyVictory notifyVictory;
    NotifyDefeat notifyDefeat;
    ScreenPlayGame screenPlayGame;
    // Start is called before the first frame update
    void Start()
    {
        InstanceNotifyVictory();
        InstanceNotifyDefeat();
        screenPlayGame = UIManager.Instance.GetExistScreen<ScreenPlayGame>();
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_HP_PLAYER, OnListenUpdateHp);
            ListenerManager.Instance.Register(ListenType.UPDATE_COUNT_ENEMY, OnListenUpdateCountEnemy);
        }
        maxHp = PlayerPrefs.GetFloat(CONSTANT.PP_MAXHPPLAYER);
    }

    private void InstanceNotifyVictory()
    {
        UIManager.Instance.ShowNotify<NotifyVictory>();
        notifyVictory = UIManager.Instance.GetExistNotify<NotifyVictory>();
        if (notifyVictory != null)
        {
            notifyVictory.Hide();
        }
    }

    private void InstanceNotifyDefeat()
    {
        UIManager.Instance.ShowNotify<NotifyDefeat>();
        notifyDefeat = UIManager.Instance.GetExistNotify<NotifyDefeat>();
        if (notifyDefeat != null)
        {
            notifyDefeat.Hide();
        }
    }

    private void OnListenUpdateHp(object HpPlayer)
    {
        healthBar.fillAmount = (float)HpPlayer / maxHp;
        if((float)HpPlayer <= 0)
        {
            screenPlayGame.isDone = true;
            OnCurso();
            screenPlayGame.Hide();
            notifyDefeat.Show(this.gameObject);
            Time.timeScale = 0;
        }
    }

    private void OnListenUpdateCountEnemy(object CountEnemy)
    {
        countEnemy.text = CountEnemy.ToString();
        if(SceneManager.GetActiveScene().name == "AI")
        {
            if(countEnemy.text == "5")
            {
                screenPlayGame.isDone = true;
                OnCurso();
                screenPlayGame.Hide();
                notifyVictory.Show(this.gameObject);
                Time.timeScale = 0;
            }
        }
    }

    private void OnCurso()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
