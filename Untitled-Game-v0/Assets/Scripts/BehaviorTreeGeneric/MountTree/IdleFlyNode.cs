using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;
using UnityEngine.UIElements.Experimental;

using static PlayerMountBT;

public class IdleFlyNode : BehaviorNode
{
    public Transform transform;

    PlayerMountController controller;
    PlayerMountData mountData;

    public IdleFlyNode(Transform transform, PlayerMountController controller, PlayerMountData mountData)
    {
        this.transform = transform;
        this.controller = controller;
        this.mountData = mountData;
        //root = GetRoot();
    }

    public override BehaviorState LogicUpdate()
    {
        //TODO: probably dont want this to be where the velocity is set
        Vector3 velocity;
        root = GetRoot();
        object t = GetData(DataLabels.velocity);
        if (t != null)
        {
            velocity = (Vector3)t;
        }
        else
        {
            velocity = mountData.velocity; //TODO: this should be base velocity
            root.SetData(DataLabels.velocity, velocity);
        }

        controller.IdleMove(transform, velocity);
        controller.RotateToVelocity(transform, velocity, mountData.yawLerpRate);

        nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
