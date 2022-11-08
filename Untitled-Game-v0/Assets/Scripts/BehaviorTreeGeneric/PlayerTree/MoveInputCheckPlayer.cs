using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeBehaviour;

public class MoveInputCheckPlayer : BehaviorNode
{
    PlayerInputHandler inputHandler;
    PlayerController3D controller3D;

    public MoveInputCheckPlayer(PlayerInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public override BehaviorState LogicUpdate()
    {
        if(inputHandler.activeMoveInput)
        {
            root = GetRoot();
            root.SetData(DataLabels.moveInput, inputHandler.moveInput);
            nodeState = BehaviorState.SUCCESS;
            return nodeState;
        }
        nodeState = BehaviorState.FAILURE;
        return nodeState;
    }
}
