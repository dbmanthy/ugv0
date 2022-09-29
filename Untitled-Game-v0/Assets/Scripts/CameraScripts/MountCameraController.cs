using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MountCameraController : MonoBehaviour
{
    public Camera mountCamera;
    public float pLerp = .5f;
    public float rLerp = .05f;
    public float upDownOffset = 30f;
    public float backFrontOffset = 0f;

    public Vector3 viewOffset;

    void Start()
    {
        viewOffset = new Vector3(0, upDownOffset, 0);
        mountCamera.transform.position = transform.position + viewOffset;
        //mountCamera.transform.LookAt(this.transform.position);
    }

    void FixedUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    void MoveCamera()
    {
        mountCamera.transform.position = Vector3.Lerp(mountCamera.transform.position, transform.position + viewOffset, pLerp);
    }

    void RotateCamera()
    {
        Vector3 rotation = mountCamera.transform.eulerAngles;
        rotation.y = transform.localEulerAngles.y;
        //rotation.z = .1f * transform.localEulerAngles.z;
        Quaternion newRotaion = Quaternion.Euler(rotation);
        mountCamera.transform.rotation = Quaternion.Lerp(mountCamera.transform.rotation, newRotaion, rLerp);
    }
}
