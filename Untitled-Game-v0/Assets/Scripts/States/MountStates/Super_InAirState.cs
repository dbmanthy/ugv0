using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_InAirState : State
{
    protected Mount mount;
    protected Vector2 input;
    protected MountController controller;
    protected PlayerMountData mountData;

    public Super_InAirState(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName, Mount mount) : base(entity, stateMachine, entityData, animationBoolName)
    {
        this.mount = mount;
        this.controller = mount.controller;
        this.mountData = mount.controller.mountData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log(mount.stateMachine.currentState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        input = mount.inputHandler.controllerInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
