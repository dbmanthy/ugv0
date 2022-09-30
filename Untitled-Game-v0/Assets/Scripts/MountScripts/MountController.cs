using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//states call these funcitons to do things to the mount
public class MountController : MonoBehaviour
{
    [SerializeField]
    public MountData mountData;

    public void Move(Vector2 input)
    {
        Vector3 inputVelocity = transform.right * input.x;
        inputVelocity.y = 0; //ignore roll
        //inputVelocity += transform.forward;
        mountData.velocity = (mountData.velocity + inputVelocity).normalized * mountData.movementSpeed;

        //mountData.velocity.y = 0;

        transform.position += mountData.velocity * Time.deltaTime;

        Debug.Log(mountData.velocity);

        RotateToVelocity();
    }

    public void RotateToVelocity()
    {
        //global rotate
        Quaternion newRotaion = Quaternion.LookRotation(mountData.velocity);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, mountData.yawLerpRate);
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
        //Vector3 rotation = transform.eulerAngles;
        //rotation.y += turnSpeed * input.x;
        //Quaternion newRotaion = Quaternion.Euler(rotation);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, mountData.yawLerpRate);
    }

    public void ExitBank()
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z = 0;
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), mountData.inRollLerpRate);

        //global rotate
        //Vector3 rotation = transform.eulerAngles;
        //Quaternion newRotaion = Quaternion.Euler(rotation);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, mountData.yawLerpRate);
    }


    public void EnterSwoop(Vector2 input)
    {
        //TODO: subtract vertical move speed componsate for uptick
        Vector3 swoopImpulse = Vector3.up * mountData.swoopDistance * input.y * Time.deltaTime;
        //transform.position += swoopImpulse;
        mountData.velocity += swoopImpulse;
    }

    public void ExitSwoop()
    {
        int correcitonDirection = mountData.velocity.y > 0 ? -1 : 1;
        int lastSwoopVelocity = (int) mountData.velocity.y;

        Vector3 swoopDamp = Vector3.up * mountData.swoopDamping * correcitonDirection * Time.deltaTime;
        mountData.velocity += swoopDamp;
        int currentSwoopVelocity = (int) mountData.velocity.y;

        //check if the prev v and curr v are differnt signs if so then have crossed the 0 boundry so set to 0
        if ((lastSwoopVelocity ^ currentSwoopVelocity) >= 0)
        {
            mountData.velocity.y = 0;
        }
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