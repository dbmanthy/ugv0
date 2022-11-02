using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class SwoopInputCheck : BehaviorNode
{
    public MountInputHandler inputHandler;

    public SwoopInputCheck(MountInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
        root = GetRoot(); //Todo: this allows for jsut gettoing it onee right?
    }

    public override BehaviorState LogicUpdate()
    {
        if (inputHandler.yInputHeldDown)
        {
            Debug.Log("jump pressed");
            nodeState = BehaviorState.SUCCESS;
        }
        else
        {
            Debug.Log("JUMP RELEASED");
            nodeState = BehaviorState.FAILURE;
        }
        return nodeState;
    }
}
