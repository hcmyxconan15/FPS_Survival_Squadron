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
    //public void Shoot()
    //{
    //    Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
    //    rb.AddForce(transform.forward*force, ForceMode.Impulse);
    //    rb.AddForce(transform.up * forceUp, ForceMode.Impulse);
    //}

    public void Shoot()
    {
        //GameObject testpositon = Instantiate(projectile);
        //testpositon.transform.SetParent(projectilePoint, true);
        //testpositon.transform.position = projectilePoint.transform.position;
        //Rigidbody rb = testpositon.GetComponent<Rigidbody>();
        //Vector3 testTransform = (player.transform.position - testpositon.transform.position) + offset;
        //rb.AddForce(testTransform * force, ForceMode.Impulse);
        //rb.AddForce(transform.up * forceUp, ForceMode.Impulse);

        Rigidbody rb = Instantiate(projectile, projectilePoint, true).GetComponent<Rigidbody>();
        projectile.transform.position = projectilePoint.position;
        Vector3 direction = player.transform.position - projectilePoint.transform.position + offset;
        //Vector3 direction = transform.forward + offset;
        rb.AddForce(direction * force, ForceMode.Impulse);
        rb.AddForce(transform.up * forceUp, ForceMode.Impulse);
    }
}
