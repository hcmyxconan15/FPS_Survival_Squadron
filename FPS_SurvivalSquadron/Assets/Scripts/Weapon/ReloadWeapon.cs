using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadWeapon : MonoBehaviour
{
    public Animator rigController;
    public WeaponAnimationEvent animationEvents;
    public ActiveWeapon activeWeapon;
    public Transform leftHand;
    public AmmoWidget ammoWidget;
    public bool isReloading;


    GameObject magazineHand;


    private void Start()
    {
        animationEvents.weaponAnimationEvent.AddListener(OnAnimatorEvent);
    }
    void Update()
    {
        RayCastWeapon weapon = activeWeapon.GetActiveWeapon();
        if (weapon)
        {
            if (Input.GetKeyDown(KeyCode.R) || weapon.ammoCount <= 0)
            {
                isReloading = true;
                rigController.SetTrigger("Reload_Weapon");
            }
            if (weapon.isFiring)
            {
                ammoWidget.Refresh(weapon.ammoCount);
            }
        }
    }

    private void OnAnimatorEvent(string evenName)
    {
        Debug.Log(evenName);
        switch (evenName)
        {
            case "detach_magazine":
                DetachMagazine();
                break;
            case "drop_magazine":
                DropMagazine();
                break;
            case "refill_magazine":
                RefillingMagazine();
                break;
            case "attach_magazine":
                AttachMagazine();
                break;
        }
    }

    private void DetachMagazine()
    {
        RayCastWeapon weapon = activeWeapon.GetActiveWeapon();
        magazineHand = Instantiate(weapon.magazine, leftHand, true);
        weapon.magazine.SetActive(false);
    } 
    private void DropMagazine()
    {
        GameObject droppedMagazine = Instantiate(magazineHand, magazineHand.transform.position, magazineHand.transform.rotation);
        droppedMagazine.AddComponent<Rigidbody>();
        droppedMagazine.AddComponent<BoxCollider>();
        magazineHand.SetActive(false);
    } 
    private void RefillingMagazine()
    {
        magazineHand.SetActive(true);
    } 
    private void AttachMagazine()
    {
        RayCastWeapon weapon = activeWeapon.GetActiveWeapon();
        weapon.magazine.SetActive(true);
        Destroy(magazineHand);
        weapon.ammoCount = weapon.clipSize;
        rigController.ResetTrigger("Reload_Weapon");
        ammoWidget.Refresh(weapon.ammoCount);
        isReloading = false;
        
    }
}
