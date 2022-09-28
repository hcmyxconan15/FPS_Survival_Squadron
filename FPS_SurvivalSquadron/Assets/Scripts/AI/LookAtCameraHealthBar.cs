using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraHealthBar : MonoBehaviour
{
    public Camera cameraToFollow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * -Vector3.back,
                    Camera.main.transform.rotation * -Vector3.down);

        //transform.rotation = Quaternion.LookRotation(transform.position - cameraToFollow.transform.position);
    }
}
