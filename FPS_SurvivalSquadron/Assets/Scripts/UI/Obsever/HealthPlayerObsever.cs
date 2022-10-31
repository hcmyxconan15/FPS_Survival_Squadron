using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayerObsever : MonoBehaviour
{
    public Image healthBar;
    private float maxHp;
    NotifyVictory notifyVictory;
    NotifyDefeat notifyDefeat;
    // Start is called before the first frame update
    void Start()
    {
        InstanceNotifyVictory();
        InstanceNotifyDefeat();
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_HP_PLAYER, OnListenUpdateHp);
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
            notifyDefeat.Show(this.gameObject);
            Time.timeScale = 0;
        }
    }


}
