 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarget;
    public UnityEngine.Animations.Rigging.Rig handIK;
    public Transform weaponParent;
    public Transform weaponLeftGrip;
    public Transform weaponRightGrip;
    RayCastWeapon weapon;

    public Animator rigController;
    

    // Start is called before the first frame update
    void Start()
    {
        

        RayCastWeapon existingWeapon = GetComponentInChildren<RayCastWeapon>();
        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }

    // Update is called once per frame
    void Update()
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
            if (Input.GetKeyDown(KeyCode.X))
            {
                bool isHoslstered = rigController.GetBool("hoslster_weapon");
                rigController.SetBool("hoslster_weapon", !isHoslstered);
            }
        }
      
    }


    public void Equip(RayCastWeapon newWeapon)
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        rigController.Play("equip_" + weapon.weaponName);
       
    }


}
