using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public float maxHealth = 300;
    float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        //healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        Debug.Log("Current Health Player: " + currentHealth);
        //animator.SetTrigger("Hurt");
        if (currentHealth <= 0.0f)
        {
            //Die(direction);
        }
    }
}
