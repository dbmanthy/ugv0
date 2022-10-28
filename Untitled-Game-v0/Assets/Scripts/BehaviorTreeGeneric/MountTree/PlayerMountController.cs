using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMountController : MonoBehaviour //TODO: maybe doesn't have to be on an object
{
    public void IdleMove(Transform transform, Vector3 velocity)
    {
       transform.position += velocity * Time.deltaTime;
    }

    public void RotateToVelocity(Transform transform, Vector3 velocity, float yawLerpRate)
    {
        //global rotate
        if (velocity != Vector3.zero)
        {
            Quaternion newRotaion = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, yawLerpRate);
        }
    }

    public Vector3 Move(Transform transform, Vector3 velocity, Vector2 input, float magnitude)
    {
        Vector3 inputVelocity = transform.right * input.x;
        inputVelocity.y = 0; //ignore roll
        velocity = (velocity + inputVelocity).normalized * magnitude;
        transform.position += velocity * Time.deltaTime;

        return velocity;
    }

    public void EnterBank(Transform transform, Vector2 input, float rotationSpeed, float minRotate, float maxRotate, float rollLerpRate)
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z -= rotationSpeed * input.x;
        localRotation.z = Utility.ConvertToAngle180(localRotation.z);
        localRotation.z = Mathf.Clamp(localRotation.z, minRotate, maxRotate);
        Quaternion newLocalRotaion = Quaternion.Euler(localRotation);
        transform.localRotation = Quaternion.Lerp(transform.rotation, newLocalRotaion, rollLerpRate);
    }

    public void ExitBank(Transform transform, float rollLerpRate)
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z = 0;
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), rollLerpRate);
    }

    public void EnterSwoop(Vector3 velocity, Vector2 input, float swoopDistance)
    {
        //TODO: add gravity scaling to make it feel like a flappy bird flap .add weight  
        //TODO: subtract vertical move speed componsate for uptick
        Vector3 swoopImpulse = Vector3.down * swoopDistance * input.y * Time.deltaTime * 100;
        //transform.position += swoopImpulse;
        velocity += swoopImpulse;
    }

    public void ExitSwoop(Vector3 velocity, float swoopDamping) //TODO: pass a reference to the velocity or return the velocity so it is updated?
    {
        int correcitonDirection = velocity.y > 0 ? -1 : 1;
        int lastSwoopVelocity = (int)velocity.y;

        Vector3 swoopDamp = Vector3.up * swoopDamping * correcitonDirection * Time.deltaTime;
        velocity += swoopDamp;
        int currentSwoopVelocity = (int)velocity.y;

        //check if the prev v and curr v are differnt signs if so then have crossed the 0 boundry so set to 0
        if ((lastSwoopVelocity ^ currentSwoopVelocity) >= 0)
        {
            velocity.y = 0;
        }
    }

    public void ChangeElevation(Vector2 input)
    {
        Debug.Log("enDive");
    }
}
