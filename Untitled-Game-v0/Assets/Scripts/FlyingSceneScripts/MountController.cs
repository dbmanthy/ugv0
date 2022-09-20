using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MountController : MonoBehaviour
{
    public void Move(Vector3 input, float moveSpeed, float rotationSpeed)
    {
        //rotate
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += rotationSpeed * input.x;
        Quaternion newRotaion = Quaternion.Euler(rotation);
        //transform.rotation = newRotaion;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotaion, .1f);

        //move
        Vector3 moveDistance = transform.forward * moveSpeed;
        transform.position += moveDistance * Time.deltaTime;
    }

    public void ChangeElevation(Vector3 input)
    {

    }
}