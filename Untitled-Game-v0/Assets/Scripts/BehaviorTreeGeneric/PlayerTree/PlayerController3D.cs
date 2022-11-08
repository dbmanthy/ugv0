using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D
{
    public void Move(Transform transform, Vector3 velocity)
    {
        transform.position += velocity * Time.deltaTime;
    }

    //ref-https://forum.unity.com/threads/moving-character-relative-to-camera.383086/
    public Vector3 InputToMoveDirection(Vector2 input, Transform localTransform)
    {
        //Get local x,z axis
        Vector3 rightAxis = localTransform.right;
        Vector3 forwardAxis = localTransform.forward;

        //project x,z axis on to gloabl xz-plane
        rightAxis.y = 0;
        forwardAxis.y = 0;
        rightAxis.Normalize();
        forwardAxis.Normalize();

        //get direction in world space
        Vector3 moveDirection = rightAxis * input.x + forwardAxis * input.y; // create unit vectors in global space and then scale
        moveDirection.Normalize();
        return moveDirection;
    }
}
