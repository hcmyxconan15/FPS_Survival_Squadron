using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
    public Transform CameraLookAt;
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    public bool isAiming;


    private Animator animator;
    private int isAimingParam = Animator.StringToHash("isAiming");
    private ActiveWeapon activeWeapon;
    protected Camera mainCamera;
    protected RayCastWeapon weapon;
    public bool isDouble = true;
    PopupPause popupPause;
    private bool isEse = false;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RayCastWeapon>();
        animator = GetComponent<Animator>();
        activeWeapon = GetComponent<ActiveWeapon>();
        popupPause = UIManager.Instance.GetExistPopup<PopupPause>();

    }

    private void Update()
    {
        isAiming = Input.GetMouseButton(1);
        animator.SetBool(isAimingParam, isAiming);

        var weapon = activeWeapon.GetActiveWeapon();
        if (weapon)
        {
            weapon.recoil.recoilModifier = isAiming ? 0.3f : 1.0f;
        }
        UseWeapon();
        //if (Input.GetKeyDown(KeyCode.LeftControl) && isDouble == false)
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //    isDouble = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftControl) && isDouble)
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.Confined;
        //    isDouble = false;
        //}
        ShowCursor();
        Ese();



    }

    private void ShowCursor()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            if(popupPause.IsHide)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void Ese()
    {
        if (Input.GetKeyDown(KeyCode.F2) && isEse == false)
        {
            Time.timeScale = 0;
            popupPause.Show(this.gameObject);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            isDouble = false;
            isEse = true;
        }
        else if (Input.GetKeyDown(KeyCode.F2) && isEse == true)
        {
            Time.timeScale = 1;
            popupPause.Hide();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isDouble = true;
            isEse = false;
        }
    }
    

    private void FixedUpdate()  
    {
        CameraUpdatePosition();
    }

    protected virtual void CameraUpdatePosition()
    {
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        CameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);
        
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    protected virtual void UseWeapon()
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
