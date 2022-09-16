using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
 

    Camera mainCamera;
    RayCastWeapon weapon;
   
    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RayCastWeapon>();
       
    }
    private void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
    private void Update()
    {
        if (weapon)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }

            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }

            weapon.UpdateBullet(Time.deltaTime);


            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();

            }
        }


    }

}
