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
        //root = GetRoot(); //Todo: this allows for jsut gettoing it onee right?
    }

    public override BehaviorState LogicUpdate()
    {
        root = GetRoot();

        if (!inputHandler.swoopInputPressed && inputHandler.swoopInputTime > 0)
        {
            Debug.Log("jump released");
            //root.SetData(DataLabels.swoopInput, inputHandler.swoopInput);
            //root.SetData(DataLabels.swoopTime, Time.time);
            nodeState = BehaviorState.RUNNING;
        }
        else
        {
            Debug.Log("jump not released");
            nodeState = BehaviorState.FAILURE;
        }
        return nodeState;
    }
}
