using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swooping_InAirState : Super_InAirState
{
    public Swooping_InAirState(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName, Mount mount) : base(entity, stateMachine, entityData, animationBoolName, mount)
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

        if(input.y == 0)
        {
            stateMachine.ChangeState(mount.idleInAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        mount.controller.EnterSwoop(input);
        mount.controller.Move(input);
    }
}
