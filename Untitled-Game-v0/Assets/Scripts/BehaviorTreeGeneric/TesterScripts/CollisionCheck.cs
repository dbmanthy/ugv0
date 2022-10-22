using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class CollisionCheck : BehaviorNode
{
    Transform transform;

    public CollisionCheck(Transform transform)
    {
        this.transform = transform;
    }

    public override BehaviorState LogicUpdate()
    {
        //Debug.Log("CollisionCheck");
        object t = GetData("collision");
        if (t == null)
        {
            Vector3 heading = transform.forward;

            object nt = GetData("heading");
            if(nt != null)
            {
                heading = (Vector3)nt;
            }

            Ray collisionCheck = new Ray(transform.position, transform.TransformDirection(heading * TestBT.raycastDist));
            Debug.DrawRay(transform.position, transform.TransformDirection(heading * TestBT.raycastDist));

            if(Physics.Raycast(collisionCheck, out RaycastHit hit, TestBT.raycastDist))
            {
                BehaviorNode root = GetRoot();
                root.SetData("collision", hit);
                nodeState = BehaviorState.SUCCESS;
                return nodeState;
            }
            nodeState = BehaviorState.FAILURE ;
            return nodeState;
        }
        nodeState = BehaviorState.SUCCESS;
        return nodeState;
    }
}
