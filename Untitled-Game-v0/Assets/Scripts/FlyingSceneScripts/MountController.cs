using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MountController : MonoBehaviour
{


    float minRotate = -50f;
    float maxRotate = 50f;
    float yawLerpRate = .1f;
    float outRollLerpRate = .5f;
    float inRollLerpRate = .22f;
    float diveSpeed = 10f;
    float climbSpeed = 4f;


    public void Move(Vector3 input, float moveSpeed, float rotationSpeed)
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        if (input.x == 0)
        {
            localRotation.z = 0;
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), inRollLerpRate);

        }
        else
        {
            localRotation.z -= rotationSpeed * input.x;
            localRotation.z = ConvertToAngle180(localRotation.z);
            localRotation.z = Mathf.Clamp(localRotation.z, minRotate, maxRotate);
            Quaternion newLocalRotaion = Quaternion.Euler(localRotation);
            transform.localRotation = Quaternion.Lerp(transform.rotation, newLocalRotaion, outRollLerpRate);
        }

        //global rotate
        Vector3 rotation = transform.eulerAngles;
        rotation.y += rotationSpeed * input.x;
        Quaternion newRotaion = Quaternion.Euler(rotation);
        //transform.rotation = newRotaion;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, yawLerpRate);


        //local move
        Vector3 moveDistance = transform.forward * moveSpeed;
        transform.position += moveDistance * Time.deltaTime;
    }

    public void ChangeElevation(Vector3 input)
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        if (input.z == 0)
        {
            localRotation.x = 0;
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), inRollLerpRate);
        }
        else
        {
            float speeed = input.z == -1 ? diveSpeed : climbSpeed;
            localRotation.x += speeed * input.z;
            localRotation.x = ConvertToAngle180(localRotation.x);
            localRotation.x = Mathf.Clamp(localRotation.x, minRotate, maxRotate);
            Quaternion newLocalRotaion = Quaternion.Euler(localRotation);
            transform.localRotation = Quaternion.Lerp(transform.rotation, newLocalRotaion, outRollLerpRate);
        }
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