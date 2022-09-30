using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//states call these funcitons to do things to the mount
public class MountController : MonoBehaviour
{
    [SerializeField]
    public MountData mountData;

    public void Move(Vector2 input, float moveSpeed)
    {
        //local move
        Vector3 moveDistance = transform.forward * moveSpeed;
        transform.position += moveDistance * Time.deltaTime;
    }

    public void EnterBank(Vector2 input, float turnSpeed)
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z -= turnSpeed * input.x;
        localRotation.z = ConvertToAngle180(localRotation.z);
        localRotation.z = Mathf.Clamp(localRotation.z, mountData.minRotate, mountData.maxRotate);
        Quaternion newLocalRotaion = Quaternion.Euler(localRotation);
        transform.localRotation = Quaternion.Lerp(transform.rotation, newLocalRotaion, mountData.outRollLerpRate);

        //global rotate
        Vector3 rotation = transform.eulerAngles;
        rotation.y += turnSpeed * input.x;
        Quaternion newRotaion = Quaternion.Euler(rotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, mountData.yawLerpRate);
    }

    public void ExitBank()
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z = 0;
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), mountData.inRollLerpRate);

        //global rotate
        Vector3 rotation = transform.eulerAngles;
        Quaternion newRotaion = Quaternion.Euler(rotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, mountData.yawLerpRate);
    }


    public void EnterSwoop(Vector2 input)
    {
        //TODO: subtract vertical move speed componsate for uptick
        transform.position += Vector3.up * mountData.swoopDistance * input.y * Time.deltaTime;
    }

    public void ExitSwoop()
    {

    }

    //public void ChangeElevation(Vector2 input)
    //{
    //    //local rotate
    //    Vector3 localRotation = transform.localEulerAngles;
    //    if (input.y == 0)
    //    {
    //        localRotation.x = 0;
    //        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), inRollLerpRate);
    //    }
    //    else
    //    {
    //        float speeed = input.y == -1 ? diveSpeed : climbSpeed;
    //        localRotation.x += speeed * input.y;
    //        localRotation.x = ConvertToAngle180(localRotation.x);
    //        localRotation.x = Mathf.Clamp(localRotation.x, minRotate, maxRotate);
    //        Quaternion newLocalRotaion = Quaternion.Euler(localRotation);
    //        transform.localRotation = Quaternion.Lerp(transform.rotation, newLocalRotaion, outRollLerpRate);
    //    }
    //}

    //sourcehttps://answers.unity.com/questions/984389/how-to-limit-the-rotation-of-transformrotate.html
    public static float ConvertToAngle180(float input)
    {
        while (input > 360)
        {
            input = input - 360;
        }
        while (input < -360)
        {
            input = input + 360;
        }
        if (input > 180)
        {
            input = input - 360;
        }
        if (input < -180)
            input = 360 + input;
        return input;
    }
}