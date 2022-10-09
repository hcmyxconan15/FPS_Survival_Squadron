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

    [SerializeField]
    private Photon.Pun.PhotonView pv;

    [SerializeField] ReloadPosition reload;
    private CinemachineFreeLook cameraFreeLook;
    private void OnEnable()
    {
        SetCamera();
    }
    public void SetCamera()
    {
        if(pv.IsMine)
        {
            reload = FindObjectOfType<ReloadPosition>();
            reload.player = this.gameObject;
            if (cameraFreeLook == null)
            {
                cameraFreeLook = FindObjectOfType<CinemachineFreeLook>();
            }
            cameraFreeLook.LookAt = lookAt;
            cameraFreeLook.Follow = follow;
        }
    }
}
