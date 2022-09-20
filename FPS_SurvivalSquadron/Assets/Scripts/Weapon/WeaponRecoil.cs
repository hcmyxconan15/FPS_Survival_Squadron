using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [Header("Camera Recoil")]
    [HideInInspector]
    public Cinemachine.CinemachineFreeLook playerCamera;
    public Cinemachine.CinemachineImpulseSource cameraShake;

    public Vector2[] recoilPattern;
    public float duration;

    private float verticalRecoil;
    private float horizontalRecoil;
    private float time;
    private int index;

    private void Awake()
    {
        cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }
    private int NextIndex(int index)
    {
        return (index + 1) % recoilPattern.Length;
    }
    public void GenerateRecoil()
    {
        time = duration;
        cameraShake.GenerateImpulse(Camera.main.transform.forward);

        horizontalRecoil = recoilPattern[index].x;
        verticalRecoil = recoilPattern[index].y;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            playerCamera.m_YAxis.Value -= ((verticalRecoil/1000) * Time.deltaTime)/duration;
            playerCamera.m_XAxis.Value -= ((horizontalRecoil/10) * Time.deltaTime)/duration;
            time -= Time.deltaTime;
        }
        
    }
}
