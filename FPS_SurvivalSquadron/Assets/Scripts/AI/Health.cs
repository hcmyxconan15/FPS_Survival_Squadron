using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float dieForce;
    protected float currentHealth;
    public float MaxHealth => maxHealth;
    public float DieForece => dieForce;
    public float CurrentHealth => currentHealth;

    // Update is called once per frame
    virtual public void TakeDamage(float amount, Vector3 direction) { }

    virtual public void Die(Vector3 direction) { }

     
}
