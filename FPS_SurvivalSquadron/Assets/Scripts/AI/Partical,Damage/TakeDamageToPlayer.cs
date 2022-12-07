using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vCharacterController
{
    public class TakeDamageToPlayer : MonoBehaviour
    {
        public float damage;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //other.GetComponent<HealthPlayer>().TakeDamage(damage);
                other.GetComponent<vThirdPersonController>().TakeDamage(damage);
            }
        }
    }
}
