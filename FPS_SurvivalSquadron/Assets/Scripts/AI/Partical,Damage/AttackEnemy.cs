using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePoint;
    public float force = 30f;
    public float forceUp = 7f;
    Transform player;
    public Vector3 offset;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {

        projectile.transform.position = projectilePoint.position;
        Rigidbody rb = Instantiate(projectile, projectilePoint, true).GetComponent<Rigidbody>();
        Vector3 direction = player.transform.position - projectilePoint.transform.position + offset;
        rb.AddForce(direction * force, ForceMode.Impulse);
        rb.AddForce(transform.up * forceUp, ForceMode.Impulse);
    }
}
