using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float dieForce;
    [HideInInspector] public float currentHealth;
    Ragdoll ragdoll;
    //SkinnedMeshRenderer skinnedMeshRenderer;
    //public float blikingHurt;
    //public float blinkDuration;
    //float blinkTimer;
    UIHealthBar healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
        //skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<UIHealthBar>();

        var ridiBodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigiBody in ridiBodies)
        {
            HitBox hitBox = rigiBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //blinkTimer -= Time.deltaTime;
        //float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        //float hurt = lerp * blikingHurt;
        //skinnedMeshRenderer.material.color = Color.white * hurt;
    }


    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        Debug.Log("Current Health: " + currentHealth);
        if(currentHealth <= 0.0f)
        {
            Die(direction);
        }
        //blinkTimer = blinkDuration;
    }

    void Die(Vector3 direction)
    {
        ragdoll.ActivateRagdoll();
        direction.y = 1;
        ragdoll.ApplyForce(direction * dieForce);
        healthBar.gameObject.SetActive(false);
    }
}
