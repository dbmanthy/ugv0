using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class AttackNode : BehaviorNode
{
    public MountInputHandler inputHandler;

    public AttackNode(MountInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public override BehaviorState LogicUpdate()
    {
        if (inputHandler.attackInput)
        {
            Debug.Log("space hit");
            inputHandler.UseAttackInput();
            nodeState = BehaviorState.SUCCESS;
        }
        else
        {
            Debug.Log("space not hit");
            nodeState = BehaviorState.FAILURE;
        }
        return nodeState;
    }
}
