using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float dieForce;
    [HideInInspector] public float currentHealth;
    Ragdoll ragdoll;
    UIHealthBar healthBar;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<UIHealthBar>();
        animator = GetComponent<Animator>();
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

    }


    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        Debug.Log("Current Health: " + currentHealth);
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0.0f)
        {
            Die(direction);
        }
    }

    void Die(Vector3 direction)
    {
        ragdoll.ActivateRagdoll();
        direction.y = 1;
        ragdoll.ApplyForce(direction * dieForce);
        healthBar.gameObject.SetActive(false);
        Destroy(gameObject,3f);
    }
}
