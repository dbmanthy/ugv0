using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFlight_InAirSate : Super_InAirState
{
    public TakeFlight_InAirSate(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName, Mount mount) : base(entity, stateMachine, entityData, animationBoolName, mount)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        mountData.velocity = mount.transform.forward * mountData.baseMovementSpeed;

        stateMachine.ChangeState(mount.idleInAirState);
    }
}
