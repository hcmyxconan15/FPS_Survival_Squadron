using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vShooter
{
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

        public virtual void OnRaycastHit(vProjectileControl vProjectileControl, Vector3 diretion)
        {
            health.TakeDamage(vProjectileControl.damage.damageValue, diretion);
        }
    }
}

