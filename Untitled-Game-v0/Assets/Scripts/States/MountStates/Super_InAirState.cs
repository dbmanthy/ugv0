using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_InAirState : State
{
    protected Mount mount;
    protected Vector2 input;
    protected MountController controller;
    protected MountData mountData;

    public Super_InAirState(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName, Mount mount) : base(entity, stateMachine, entityData, animationBoolName)
    {
        this.mount = mount;
        this.controller = mount.controller;
        this.mountData = mount.mountData;
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
        input = mount.inputHandler.bankInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}