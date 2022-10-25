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
}
