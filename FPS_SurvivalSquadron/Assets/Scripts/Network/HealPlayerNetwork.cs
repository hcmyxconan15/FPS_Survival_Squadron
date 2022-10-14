using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealPlayerNetwork : Health
{
    public GameObject healthBar;
    public GameObject borderHealth;
    PhotonView pv => GetComponent<PhotonView>();

    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        
 
    }

    void SetHealth()
    {
        healthBar.GetComponent<Image>().fillAmount = currentHealth / maxHealth;
    }
    public override void TakeDamage(float amount, Vector3 direction)
    {
        pv.RPC("RPC_TakeDamg", RpcTarget.All, amount, direction);
    }

    [PunRPC]
    void RPC_TakeDamg(float damg, Vector3 direction)
    {
        currentHealth -= damg;
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
