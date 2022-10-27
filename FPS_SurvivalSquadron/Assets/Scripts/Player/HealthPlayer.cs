using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public float maxHealth = 300;
    float currentHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        PlayerPrefs.SetFloat(CONSTANT.PP_MAXHPPLAYER, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            //Die(direction);
        }
        ListenerManager.Instance.BroadCast(ListenType.UPDATE_HP_PLAYER, currentHealth);
    }
}
