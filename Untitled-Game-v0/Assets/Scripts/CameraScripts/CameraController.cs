using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float viewHeight = 10f;
    public float pLerp = .02f;
    public float rLerp = .01f;

    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y + viewHeight, target.position.z);
    }

    void FixedUpdate()
    {
        //move
        Vector3 updatedTarget = new Vector3(target.position.x, target.position.y + viewHeight, target.position.z);
        transform.position = Vector3.Lerp(transform.position, updatedTarget, pLerp);

        //rotate
        Vector3 rotation = transform.eulerAngles;
        rotation.y = target.localEulerAngles.y;
        Quaternion newRotaion = Quaternion.Euler(rotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, rLerp);
    }
}
