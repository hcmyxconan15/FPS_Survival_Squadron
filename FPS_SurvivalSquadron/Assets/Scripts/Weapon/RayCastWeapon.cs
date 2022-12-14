using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCastWeapon : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
        public TrailRenderer tracer;
        public int bounce;
    }

    [Header("Weapon")]
    public ActiveWeapon.WeaponSlot weaponslot;
    public bool isFiring = false;
    public int fireRate = 25;
    public float bulletSpeed = 1000f;
    public float bulletDrop = 0f;
    public int maxBounces = 0;
    public bool debug = false;
    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;

    [Header("Raycast destination")]
    public Transform raycastOrigin;
    public Transform raycastDestination;

    private Ray ray;
    private RaycastHit hitInfo;
    private float accumulatedTime;
    private List<Bullet> bullets = new List<Bullet>();
    private float maxLifeTime = 3.0f;

    public string weaponName;
    [Header("Recoil system")]
    public WeaponRecoil recoil;

    [Header("Reloading")]
    public GameObject magazine;

    [Header("accumulate Count")]
    public int ammoCount;
    public int clipSize;

    [Header("AI")]
    public float damage = 10f;


    private void Awake()
    {
        recoil = GetComponent<WeaponRecoil>();
    }
    private Vector3 GetPosition(Bullet bullet)
    {
        // p + v*t + 0.5*g*t*t
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition)
            + (bullet.initialVelocity * bullet.time)
            + (0.5f * gravity * bullet.time * bullet.time);
    }

    private Bullet CreateBullet(Vector3 postion, Vector3 velocity)
    {
        Bullet bullet = new Bullet();
        bullet.initialPosition = postion;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;
        bullet.tracer = Instantiate(tracerEffect, postion, Quaternion.identity);
        bullet.tracer.AddPosition(postion);
        bullet.bounce = maxBounces;
        return bullet;
    }




    public void StartFiring()
    {
        isFiring = true;
        accumulatedTime = 0.0f;
        recoil.Reset();
        FireBullet();
        //objectPool.GetObject();
    }

    public void UpdateWeapon(float deltaTime)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartFiring();
        }
        if (isFiring)
        {
            UpdateFiring(deltaTime);
        }
        UpdateBullet(deltaTime);
        if (Input.GetButtonUp("Fire1"))
        {
            StopFiring();
        }

    }


    public void UpdateFiring(float deltaTime)
    {
        accumulatedTime += deltaTime;
        float fireInterval = 1.0f / fireRate;
        while (accumulatedTime >= 0.0f)
        {
            FireBullet();
            accumulatedTime -= fireInterval;
        }
    }

    public void UpdateBullet(float deltaTime)
    {
        SimulateBullet(deltaTime);
        DestroyBullet();
    }

    private void SimulateBullet(float deltaTime)
    {
        bullets.ForEach(bullet => {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += deltaTime;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);
        });
    }

    private void DestroyBullet()
    {
        bullets.RemoveAll(bullet => bullet.time >= maxLifeTime);
    }

    private void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        ray.origin = start;
        ray.direction = direction;

        //Color debugColor = Color.green;

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            //bullet.tracer.transform.position = hitInfo.point;
            bullet.time = maxLifeTime;
            //end = hitInfo.point;
            //debugColor = Color.red;

            //bullet ricochet
            if (bullet.bounce > 0)
            {
                bullet.time = 0;
                bullet.initialPosition = hitInfo.point;
                bullet.initialVelocity = Vector3.Reflect(bullet.initialVelocity, hitInfo.normal);
                bullet.bounce--;
            }

            // collision impulse
            //var rb2d = hitInfo.collider.GetComponent<Rigidbody>();
            //if (rb2d)
            //{
            //    rb2d.AddForceAtPosition(ray.direction * 20, hitInfo.point, ForceMode.Impulse);
            //}

            //var hitBox = hitInfo.collider.GetComponent<HitBox>();
            //if(hitBox)
            //{
            //    hitBox.OnRaycastHit(this, ray.direction);
            //} 
        }
        bullet.tracer.transform.position = end;
        //if (debug)
        //{
        //    Debug.DrawLine(start, end, debugColor, 1.0f);
        //}       
        //else
        //{
        //    bullet.tracer.transform.position = end;
        //}
    }

    private void FireBullet()
    {
        if(ammoCount <= 0)
        {
            return;
        }
        ammoCount--;

        for (int i = 0; i < muzzleFlash.Length; i++)
        {
            muzzleFlash[i].Emit(1);
        }

        Vector3 velocity = (raycastDestination.position - raycastOrigin.position).normalized * bulletSpeed;
        var bullet = CreateBullet(raycastOrigin.position, velocity);
        bullets.Add(bullet);
        //objectPool.GetObject();ss
        AudioManager.Instance.PlaySoundEffect("Bullet");
        recoil.GenerateRecoil(weaponName);

    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
