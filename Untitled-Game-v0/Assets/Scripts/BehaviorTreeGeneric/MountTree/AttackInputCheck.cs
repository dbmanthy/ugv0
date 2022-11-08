using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class AttackInputCheck : BehaviorNode
{
    public MountInputHandler inputHandler;

    public AttackInputCheck(MountInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public override BehaviorState LogicUpdate()
    {
        if (inputHandler.attackInput)
        {
            inputHandler.UseAttackInput();
            nodeState = BehaviorState.SUCCESS;
        }
        else
        {
            nodeState = BehaviorState.FAILURE;
        }
        return nodeState;
    }
}
