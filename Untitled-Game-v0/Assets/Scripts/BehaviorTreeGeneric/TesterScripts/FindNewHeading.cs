using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class FindNewHeading : BehaviorNode
{
    public Transform transform;

    public FindNewHeading(Transform transform)
    {
        this.transform = transform;
    }

    public override BehaviorState LogicUpdate()
    {
        //Debug.Log("FindNewHeading");
        int flipper = 1;
        float rotationAngle = 0f;

        RaycastHit hit = (RaycastHit)GetData("collision");

        Vector3 checkAngle = transform.forward;
        Vector3 rayDirection = transform.TransformDirection(checkAngle * TestBT.raycastDist);
        Ray collisionCheck = new Ray(transform.position, rayDirection);

        while (Physics.Raycast(collisionCheck, out hit, TestBT.raycastDist))
        {
            flipper *= -1;
            rotationAngle += TestBT.theta;
            //rotate vector
            checkAngle = Quaternion.AngleAxis(rotationAngle * flipper, transform.up) * checkAngle;
            rayDirection = transform.TransformDirection(checkAngle * TestBT.raycastDist);

            collisionCheck = new Ray(transform.position, rayDirection);
            Debug.DrawRay(transform.position, rayDirection);
        }

        BehaviorNode root = GetRoot();
        root.SetData("heading", rayDirection);
        root.ClearData("collision");

        nodeState = BehaviorState.SUCCESS;
        return nodeState;
    }
}
