using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;
using UnityEngine.UIElements;

public class FlyNode : BehaviorNode
{
    public Transform transform;

    PlayerMountController controller;
    PlayerMountData mountData;

    public FlyNode(Transform transform, PlayerMountController controller, PlayerMountData mountData)
    {
        this.transform = transform;
        this.controller = controller;
        this.mountData = mountData;
        //root = GetRoot();
    }

    public override BehaviorState LogicUpdate()
    {
        Vector2 input;
        object t = GetData(DataLabels.bankInput);
        if (t != null)
        {
            input = (Vector2)t;
        }
        else
        {
            input = Vector2.zero;
        }

        Vector3 velocity;
        t = GetData(DataLabels.velocity);
        if (t != null)
        {
            velocity = (Vector3)t;
        }
        else
        {
            velocity = mountData.velocity; //TODO: this should be base velocity
            root.SetData(DataLabels.velocity, velocity);
        }

        //Vector3 velocity = (Vector3)GetData(DataLabels.velocity); //TODO: is it safe to assume this is never null? nope
        root = GetRoot();
        controller.EnterBank(transform, input, mountData.rotationSpeed, mountData.minRotate, mountData.maxRotate, mountData.inRollLerpRate);
        if (input.y != 0)
        {
            velocity = controller.EnterSwoop(velocity, input, velocity.magnitude, mountData.swoopRate, 4, 5);
        }
        else if (velocity.y != 0)
        {
            velocity = controller.ExitSwoop(velocity, velocity.magnitude, mountData.swoopDampRate);
        }
        velocity = controller.TurnXZ(velocity, input, mountData.turnRateXY, velocity.magnitude);
        controller.Move(transform, velocity);
        controller.RotateToVelocity(transform, velocity, mountData.yawLerpRate);
        
        root.SetData(DataLabels.velocity, velocity);

        BehaviorState nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
