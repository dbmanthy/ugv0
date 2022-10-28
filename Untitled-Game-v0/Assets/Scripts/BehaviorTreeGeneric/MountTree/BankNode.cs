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

        Vector3 velocity = (Vector3)GetData(DataLabels.velocity); //TODO: is it safe to assume this is never null?

        controller.EnterBank(transform, input, mountData.rotationSpeed, mountData.minRotate, mountData.maxRotate, mountData.inRollLerpRate);
        velocity = controller.Move(transform, velocity, input, velocity.magnitude);
        controller.RotateToVelocity(transform, velocity, mountData.yawLerpRate);

        root = GetRoot();
        root.SetData(DataLabels.velocity, velocity);

        BehaviorState nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
