using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Invector.vShooter
{
    public class HealthEnemy : Health
    {
        Ragdoll ragdoll;
        //UIHealthBar healthBar;
        Animator animator;
        [Header("Partical")]
        public bool isParticalDestroy = false;
        public GameObject particalDestroy;
        [Header("HealthBar")]
        public GameObject healthBar;
        public GameObject borderHealth;
        bool coolDownRagdoll = true;
        // Start is called before the first frame update
        void Start()
        {
            ragdoll = GetComponent<Ragdoll>();
            currentHealth = maxHealth;
            animator = GetComponent<Animator>();
            var ridiBodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rigiBody in ridiBodies)
            {
                HitBox hitBox = rigiBody.gameObject.AddComponent<HitBox>();
                hitBox.health = this;
            }
            //screenPlayGame.countEnemy = 0;
            //ListenerManager.Instance.BroadCast(ListenType.UPDATE_COUNT_ENEMY, screenPlayGame.countEnemy);
            ListenerManager.Instance.BroadCast(ListenType.UPDATE_COUNT_ENEMY, ScreenPlayGame.countEnemy);

        }

        // Update is called once per frame
        void Update()
        {
            SetHealth();
        }

        void SetHealth()
        {
            healthBar.GetComponent<Image>().fillAmount = currentHealth / maxHealth;
        }

        public override void TakeDamage(float amount, Vector3 direction)
        {
            currentHealth -= amount;
            animator.SetTrigger("Hurt");
            if (currentHealth <= 0.0f && coolDownRagdoll)
            {
                Die(direction);
                ListenerManager.Instance.BroadCast(ListenType.UPDATE_COUNT_ENEMY,++ScreenPlayGame.countEnemy);
                coolDownRagdoll = false;
                StartCoroutine(CoolDown(3f));
            }
        }

        IEnumerator CoolDown(float time)
        {
            yield return new WaitForSeconds(time);
            coolDownRagdoll = true;
        }

        public override void Die(Vector3 direction)
        {
            DestroyGameObject();
            ragdoll.ActivateRagdoll();
            direction.y = 1;
            ragdoll.ApplyForce(direction * dieForce);
            healthBar.SetActive(false);
            borderHealth.SetActive(false);
            Destroy(gameObject, 3f);
        }

        void DestroyGameObject()
        {
            if (isParticalDestroy)
            {
                GameObject explosion = Instantiate(particalDestroy, transform.position, transform.rotation);
                explosion.transform.SetParent(transform);
                Destroy(explosion, 3f);
            }
        }
    }
}
