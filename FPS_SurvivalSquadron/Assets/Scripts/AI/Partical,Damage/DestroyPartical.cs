using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPartical : MonoBehaviour
{
    public GameObject VFX;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        if(health.currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(VFX, transform.position, transform.rotation);
            Destroy(explosion, 0.75f);
        }
    }
}
