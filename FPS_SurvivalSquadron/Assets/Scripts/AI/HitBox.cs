using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    public void OnRaycastHit(RayCastWeapon weapon, Vector3 diretion)
    {
        health.TakeDamage(weapon.damage, diretion);
    }
}
