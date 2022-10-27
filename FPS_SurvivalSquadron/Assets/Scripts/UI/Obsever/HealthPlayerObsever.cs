using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayerObsever : MonoBehaviour
{
    public Image healthBar;
    private float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_HP_PLAYER, OnListenUpdateHp);
        }
        maxHp = PlayerPrefs.GetFloat(CONSTANT.PP_MAXHPPLAYER);
    }

    private void OnListenUpdateHp(object HpPlayer)
    {
        healthBar.fillAmount = (float)HpPlayer / maxHp;
    }
}
