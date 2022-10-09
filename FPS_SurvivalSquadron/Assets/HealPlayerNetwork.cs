using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealPlayerNetwork : Health
{
    public GameObject healthBar;
    public GameObject borderHealth;


    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        
 
    }

    void SetHealth()
    {
        healthBar.GetComponent<Image>().fillAmount = currentHealth / maxHealth;
    }
    [PunRPC]
    public override void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        SetHealth();
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth <= 0.0f)
        {
            Die(direction);
        }
    }

    public override void Die(Vector3 direction)
    {
        healthBar.SetActive(false);
        borderHealth.SetActive(false);
        Destroy(gameObject, 3f);
    }
}
