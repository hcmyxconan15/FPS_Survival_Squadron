using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetCameraFreeLook : MonoBehaviour
{
    [SerializeField]
    private Transform follow;

    [SerializeField]
    private Transform lookAt;

    private CinemachineFreeLook cameraFreeLook;
    private void Awake()
    {
        SetCamera();
    }
    public void SetCamera()
    {
        
        if(cameraFreeLook == null)
        {
            cameraFreeLook = FindObjectOfType<CinemachineFreeLook>();
        }
        cameraFreeLook.LookAt = lookAt;
        cameraFreeLook.Follow = follow;
    }
}
