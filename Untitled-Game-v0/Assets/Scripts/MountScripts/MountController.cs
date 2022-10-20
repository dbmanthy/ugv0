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
        float currentSpeed = mountData.velocity.magnitude;
        Vector3 inputVelocity = transform.right * input.x;
        inputVelocity.y = 0; //ignore roll                      --> TODO: is this breaking swoop?!
        mountData.velocity = (mountData.velocity + inputVelocity).normalized * currentSpeed;
        transform.position += mountData.velocity * Time.deltaTime;

        RotateToVelocity();
    }

    public void Move()
    {
        transform.position += mountData.velocity * Time.deltaTime;
        RotateToVelocity();
    }

    public void RotateToVelocity()
    {
        //global rotate
        if (mountData.velocity != Vector3.zero)
        {
            Quaternion newRotaion = Quaternion.LookRotation(mountData.velocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, mountData.yawLerpRate);
        }
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
    }

    public void ExitBank()
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z = 0;
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), mountData.inRollLerpRate);
    }


    public void EnterSwoop(Vector2 input)
    {
        //TODO: add gravity scaling to make it feel like a flappy bird flap .add weight  
        //TODO: subtract vertical move speed componsate for uptick
        Vector3 swoopImpulse = Vector3.down * mountData.swoopDistance * input.y * Time.deltaTime * 100;
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

    public void ChangeElevation(Vector2 input)
    {
        Debug.Log("enDive");
    }

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