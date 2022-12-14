 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class ActiveWeapon : MonoBehaviour
{
    public enum WeaponSlot
    {
        Primary = 0,
        Secondary = 1
    }
    [Header("Switching weapon")]
    public bool isChaningWeapon = false;
    public Transform[] weaponSlots;

    RayCastWeapon[] equipped_weapons = new RayCastWeapon[2];
    private int activeWeaponIndex;
    private bool isHolstered = false;
    [Header("Animator")]
    public Animator rigController;

    [Header("Camera")]
    public PlayerAiming PlayerAiming;

    public Transform crossHairTarget;

    [Header("accumulate Count")]
    public AmmoWidget ammoWidget;


    


    // Start is called before the first frame update
    void Start()
    {
        

        RayCastWeapon existingWeapon = GetComponentInChildren<RayCastWeapon>();
        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }

    public bool IsFiring()
    {
        RayCastWeapon currentWeapon = GetActiveWeapon();
        if (!currentWeapon)
        {
            return false;
        }
        return currentWeapon.isFiring;
    }

    public RayCastWeapon GetActiveWeapon()
    {
        return GetWeapon(activeWeaponIndex);
    }
    RayCastWeapon GetWeapon(int index)
    {
        if(index < 0 || index >= equipped_weapons.Length)
        {
            return null;
        }
        return equipped_weapons[index];
    }

    // Update is called once per frame
    void Update()
    {
        Action();

    }

    protected virtual void Action()
    {
        var weapon = GetWeapon(activeWeaponIndex);
        bool notSprinting = rigController.GetCurrentAnimatorStateInfo(2).shortNameHash == Animator.StringToHash("notSprinting");
        if (weapon && !isHolstered && notSprinting)
        {

            weapon.UpdateWeapon(Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleActiveWeapon();

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("1");
            SetActiveWeapon(WeaponSlot.Primary);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Debug.Log("2");
            SetActiveWeapon(WeaponSlot.Secondary);
        }
    }

    public void Equip(RayCastWeapon newWeapon)
    {
        int weaponSlotIndex = (int)newWeapon.weaponslot;
        var weapon = GetWeapon(weaponSlotIndex);
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        //take recoil camera = playerCamera
        weapon.recoil.PlayerAiming = PlayerAiming;

        weapon.recoil.rigController = rigController;
        weapon.transform.SetParent(weaponSlots[weaponSlotIndex],false);
        equipped_weapons[weaponSlotIndex] = weapon;

        SetActiveWeapon(newWeapon.weaponslot);
        ammoWidget.Refresh(weapon.ammoCount);
    }

    private void ToggleActiveWeapon()
    {
        bool isHoslstered = rigController.GetBool("hoslster_weapon");
        if (isHoslstered)
        {
            StartCoroutine(ActivateWeapon(activeWeaponIndex));
        }
        else
        {
            StartCoroutine(HolsterWeapon(activeWeaponIndex));
        }
    }
    public void SetActiveWeapon(WeaponSlot Weaponslot)
    {
        int holsterIndex = activeWeaponIndex;
        int activeIndex = (int)Weaponslot;
        if(holsterIndex == activeIndex)
        {
            holsterIndex = -1;
        }
        StartCoroutine(SwitchWeapon(holsterIndex, activeIndex));

    }
    IEnumerator SwitchWeapon(int holsterIndex, int activeIndex)
    {
        rigController.SetInteger("WeaponIndex", activeIndex);
        yield return StartCoroutine(HolsterWeapon(holsterIndex));
        yield return StartCoroutine(ActivateWeapon(activeIndex));
        activeWeaponIndex = activeIndex;
    }
    IEnumerator HolsterWeapon(int index)
    {
        isChaningWeapon = true;
        isHolstered = true;
        var weapon = GetWeapon(index);
        if(weapon)
        {
            rigController.SetBool("hoslster_weapon", true);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        }
        isChaningWeapon = false;
    }

    IEnumerator ActivateWeapon(int index)
    {
        isChaningWeapon = true;
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("hoslster_weapon", false);
            rigController.Play("equip_" + weapon.weaponName);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            isHolstered = false;
        }
        isChaningWeapon = false;
    }


}
