using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;
using static PlayerMountBT;

public class InputCheck : BehaviorNode
{
    public MountInputHandler inputHandler;

    public InputCheck(MountInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public override BehaviorState LogicUpdate()
    {
        root = GetRoot();//TODO:Theres gotta a better way to cache the root

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
