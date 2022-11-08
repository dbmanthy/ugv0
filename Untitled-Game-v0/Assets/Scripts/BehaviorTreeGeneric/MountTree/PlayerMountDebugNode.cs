using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeBehaviour;

public class PlayerMountDebugNode : BehaviorNode
{
    BehaviorNode _root;

    public PlayerMountDebugNode()
    {
        _root = GetRoot();
    }

    public override BehaviorState LogicUpdate()
    {//TODO draw ray velocity  or draw gizmos"
        root = GetRoot();
        Debug.Log("Velocity " + root.GetData(DataLabels.velocity));

        nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
