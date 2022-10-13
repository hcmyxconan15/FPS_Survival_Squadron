using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthEnemy : Health
{
    Ragdoll ragdoll;
    //UIHealthBar healthBar;
    Animator animator;
    public GameObject particalDestroy;
    public GameObject healthBar;
    public GameObject borderHealth;


    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
        //healthBar = GetComponentInChildren<UIHealthBar>();
        animator = GetComponent<Animator>();
        var ridiBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigiBody in ridiBodies)
        {
            HitBox hitBox = rigiBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth();
    }

    void  SetHealth()
    {
        healthBar.GetComponent<Image>().fillAmount = currentHealth / maxHealth;
    }

    public override void  TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        //healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        Debug.Log("Current Health: " + currentHealth);
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0.0f)
        {
            Die(direction);
            DestroyGameObject();
        }
    }

    public override void Die(Vector3 direction)
    {
        ragdoll.ActivateRagdoll();
        direction.y = 1;
        ragdoll.ApplyForce(direction * dieForce);
        healthBar.SetActive(false);
        borderHealth.SetActive(false);
        Destroy(gameObject, 3f);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(particalDestroy, transform.position, transform.rotation);
        Destroy(explosion, 0.75f);
    }
}
