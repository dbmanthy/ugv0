using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class Move : BehaviorNode
{
    public Transform transform;

    public Move(Transform transform)
    {
        this.transform = transform;
    }

    public override BehaviorState EvaluateNode()
    {
        Debug.Log("Move");
        Vector3 heading = transform.forward;

        object t = GetData("heading");
        if(t != null)
        {
            heading = (Vector3)t;
        }

        transform.position += heading * TestBT.moveSpeed * Time.deltaTime;

        nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
