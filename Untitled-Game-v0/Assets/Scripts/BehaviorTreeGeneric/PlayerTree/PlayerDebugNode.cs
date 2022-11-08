using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeBehaviour;

public class PlayerDebugNode : BehaviorNode
{
    public override BehaviorState LogicUpdate()
    {
        Debug.Log("tick");
        nodeState = BehaviorState.RUNNING;
        return nodeState;
    }
}
