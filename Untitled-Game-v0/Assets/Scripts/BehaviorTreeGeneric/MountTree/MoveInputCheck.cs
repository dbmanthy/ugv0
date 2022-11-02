using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;
using static PlayerMountBT;

public class MoveInputCheck : BehaviorNode
{
    public MountInputHandler inputHandler;

    public MoveInputCheck(MountInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
        //root = GetRoot();//TODO:Is there a better way to cache the root?d
    }

    public override BehaviorState LogicUpdate()
    {
        root = GetRoot();
        if(inputHandler.moveInputContext.started)//TODO:should this be started or preformed
        {
            Vector2 input = inputHandler.moveInput;
            root.SetData(DataLabels.bankInput, input);
            nodeState = BehaviorState.SUCCESS;
        }
        else
        {
            root.ClearData(DataLabels.bankInput);
            nodeState = BehaviorState.FAILURE;
        }
        return nodeState;
    }
}
