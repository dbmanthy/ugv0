using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;
using UnityEngine.UIElements;

public class BankNode : BehaviorNode
{
    public Transform transform;

    PlayerMountController controller;
    PlayerMountData mountData;

    public BankNode(Transform transform, PlayerMountController controller, PlayerMountData mountData)
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
        velocity = controller.Move(transform, velocity, input, velocity.magnitude);
        controller.RotateToVelocity(transform, velocity, mountData.yawLerpRate);

        root.SetData(DataLabels.velocity, velocity);

        BehaviorState nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
