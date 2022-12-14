using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [Header("Camera Recoil")]
    [HideInInspector] public PlayerAiming PlayerAiming;
    [HideInInspector] public Cinemachine.CinemachineImpulseSource cameraShake;
    [HideInInspector] public Animator rigController;

    public Vector2[] recoilPattern;
    public float duration;
    public float recoilModifier = 1.0f;


    private float verticalRecoil;
    private float horizontalRecoil;
    private float time;
    private int index;


    private void Awake()
    {
        cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }
    private void Start()
    {
      
    }
    public void Reset()
    {
        index = 0;
    }
    private int NextIndex(int index)
    {
        return (index + 1) % recoilPattern.Length;
    }
    public void GenerateRecoil(string weaponName)
    {
        time = duration;
        cameraShake.GenerateImpulse(Camera.main.transform.forward);

        horizontalRecoil = recoilPattern[index].x;
        verticalRecoil = recoilPattern[index].y;

        index = NextIndex(index);
        
        rigController.Play("Weapon_Recoil_" + weaponName,-1, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            PlayerAiming.yAxis.Value -= (((verticalRecoil/10) * Time.deltaTime)/duration) * recoilModifier;
            PlayerAiming.xAxis.Value -= (((horizontalRecoil/10) * Time.deltaTime)/duration) * recoilModifier;
            time -= Time.deltaTime;
        }
        
    }
}
