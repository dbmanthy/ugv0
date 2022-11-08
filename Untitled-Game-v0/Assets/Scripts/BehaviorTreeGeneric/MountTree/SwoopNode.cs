using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class SwoopNode : BehaviorNode
{
    public Transform transform;

    PlayerMountController controller;
    PlayerMountData mountData;

    public SwoopNode(Transform transform, PlayerMountController controller, PlayerMountData mountData)
    {
        this.transform = transform;
        this.controller = controller;
        this.mountData = mountData;
        //root = GetRoot();
    }

    public override BehaviorState LogicUpdate()
    {
        Vector3 velocity;
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
        Debug.Log("en'swoop");
        //controller.EnterSwoop();
        nodeState = BehaviorState.SUCCESS;
        return nodeState;
    }
}
