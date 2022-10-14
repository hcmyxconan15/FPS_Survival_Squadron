using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalColiision : MonoBehaviour
{
    public float dame;
    public ParticleSystem particleSystem;
    public List<ParticleCollisionEvent> particleCollisionEvents;
 

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleCollisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, other, particleCollisionEvents);
        for(int i = 0; i < particleCollisionEvents.Count;i++)
        {
            var collider = particleCollisionEvents[i].colliderComponent;
            if(collider.tag == "Player")
            {
                var health = collider.GetComponent<HealthPlayer>();
                health.TakeDamage(dame);
            }
        }
    }
}
