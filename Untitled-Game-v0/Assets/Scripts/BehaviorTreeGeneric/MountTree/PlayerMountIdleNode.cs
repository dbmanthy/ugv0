using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;
using UnityEngine.UIElements.Experimental;

public class PlayerMountIdleNode : BehaviorNode
{
    public Transform transform;

    PlayerMountController controller;
    PlayerMountData mountData;

    public PlayerMountIdleNode(Transform transform, PlayerMountController controller, PlayerMountData mountData)
    {
        this.transform = transform;
        this.controller = controller;
        this.mountData = mountData;
    }

    public override BehaviorState LogicUpdate()
    {
        //TODO: probably dont want this to be where the velocity is set
        Vector3 velocity;

        object t = GetData("velocity");
        if (t != null)
        {
            velocity = (Vector3)t;
        }
        else
        {
            velocity = mountData.velocity; //TODO: this should be base velocity
            BehaviorNode root = GetRoot();
            root.SetData("velocity", velocity);
        }

        controller.IdleMove(transform, velocity);
        controller.RotateToVelocity(transform, velocity, mountData.yawLerpRate);

        nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
