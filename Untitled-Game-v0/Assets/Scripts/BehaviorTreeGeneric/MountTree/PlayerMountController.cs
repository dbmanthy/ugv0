using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;

public class PlayerMountController : MonoBehaviour //TODO: maybe doesn't have to be on an object
{
    public void Move(Transform transform, Vector3 velocity)
    {
       transform.position += velocity * Time.deltaTime;//TODO only one functions should actually update the position so its not updated multiple times per frame
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
    
    public Vector3 TurnXZ(Vector3 velocity, Vector2 input, float turnRate, float magnitude)//TODO:add magnitued so that speed can be incorperated
    {
        float theta = turnRate * input.x;
        velocity = Quaternion.AngleAxis(theta, Vector3.up) * velocity;
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

    public void ExitBank(Transform transform, float rollLerpRate)//seems to be handled by EnterBank ... somehow
    {
        //local rotate
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.z = 0;
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(localRotation), rollLerpRate);
    }

    public Vector3 EnterSwoop(Vector3 velocity, Vector2 input, float magnitude, float swoopRate, float maxDiveAngle, float maxClimbAngle) //TODO add a small impulse (dodge) right as its pressed
    {
        //set rotation axis
        Vector3 rotationAxis = transform.right;
        rotationAxis.y = 0; //ignore roll
        //limit dive and climb angless
        float currentTheta = (Vector3.Angle(Vector3.left, velocity) * Mathf.PI)/180;//TODO: limmit climb and dive angle - and make it so the longer its held the more extream it gets .. almost
        float thetaPercent = Mathf.Abs(currentTheta / (Mathf.PI / 2));
        if(thetaPercent == Mathf.PI/4 && ((int)currentTheta ^ (int)input.y) < 0)//TODO limit pi/4 shouln't be hard coded ... this isn't actually working
        {
            thetaPercent = 0;
            return velocity;//TODO why does it just spinn
        }
        //swoop
        float theta = swoopRate * input.y * thetaPercent;
        //Debug.Log("current theta " + currentTheta + "theta" + theta);
        velocity = Quaternion.AngleAxis(theta, rotationAxis) * velocity;
        return velocity;
    }

    public Vector3 ExitSwoop(Vector3 velocity, float magnitude, float swoopDampingRate)
    {
        //int correcitonDirection = velocity.y > 0 ? -1 : 1;
        //int lastSwoopVelocity = (int)velocity.y;

        //// set rotation axis
        //Vector3 rotationAxis = transform.right;
        //rotationAxis.y = 0; //ignore roll
        //float theta = swoopDampingRate * correcitonDirection;
        //velocity = Quaternion.AngleAxis(theta, rotationAxis) * velocity;
        ////Vector3 swoopDamp = Vector3.up * swoopDamping * correcitonDirection * Time.deltaTime;
        //////velocity += swoopDamp;
        ////velocity = (velocity + swoopDamp).normalized * magnitude;

        ////check if the prev v and curr v are differnt signs if so then have crossed the 0 boundry so set to 0
        //int currentSwoopVelocity = (int)velocity.y;
        //if ((lastSwoopVelocity ^ currentSwoopVelocity) >= 0)
        //{
        //    velocity.y = 0;
        //}

        return velocity;
    }

    public void ChangeElevation(Vector2 input)
    {
        Debug.Log("enDive");
    }
}


//Vector3 inputVelocity = transform.right * input.x;
//inputVelocity.y = 0; //ignore roll
//velocity = (velocity + inputVelocity).normalized * magnitude; works is 2d
/*Rotating a vector::
 * -https://answers.unity.com/questions/46770/rotate-a-vector3-direction.html
 * -https://stackoverflow.com/questions/14607640/rotating-a-vector-in-3d-space
 */
//float theta = Mathf.Atan2(velocity.y - inputVelocity.y, velocity.x - inputVelocity.x); // but this doesn't work if its zero ...
