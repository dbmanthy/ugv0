using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationChange_InAirState : Super_InAirState
{
    public float targetElevation = 0f;

    bool midElevationChange = false;

    public ElevationChange_InAirState(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName, Mount mount) : base(entity, stateMachine, entityData, animationBoolName, mount)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void EnterState()
    {
        base.EnterState();
        //targetElevation = mountData.
        midElevationChange = mountData.enRoute;
    }

    public override void ExitState()
    {
        base.ExitState();
        mountData.enRoute = midElevationChange;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (mount.transform.position.y == targetElevation)
        {
            stateMachine.ChangeState(mount.idleInAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        controller.ChangeElevation(input);
    }
}
