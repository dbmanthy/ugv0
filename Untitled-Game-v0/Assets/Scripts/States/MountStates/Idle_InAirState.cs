using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_InAirState : Super_InAirState
{
    public Idle_InAirState(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName, Mount mount) : base(entity, stateMachine, entityData, animationBoolName, mount)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(input.x != 0)
        {
            stateMachine.ChangeState(mount.bankingInAirState);
        }
        //if(input.y != 0)
        //{
        //    stateMachine.ChangeState(mount.swoopingInAirState);
        //}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if(mount.transform.localEulerAngles.z != 0)
        {
            mount.controller.ExitBank();
        }

        //if(mountData.velocity.y != 0)
        //{
        //    mount.controller.ExitSwoop();
        //}
        
        if(input.y != 0)
        {
            mountData.velocity.y = 10;
        }

        mount.controller.Move(); //?: why is mountData. okay but controller. causes reference error ? has to be mount.controller. but why ... because were creating this before mountData so mountDat did not yet exitst to reference
    }
}
