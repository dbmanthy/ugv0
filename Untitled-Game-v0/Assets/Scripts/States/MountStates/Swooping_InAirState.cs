using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swooping_InAirState : Super_InAirState
{
    Vector2 initialInput;
    bool yInputActive = false;

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
        initialInput = input;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (input.y == 0 && (Time.time - startTime) > mountData.swoopTimeBuffer && (Time.time - startTime) < mountData.elevationChangeTimeBuffer)
        {
            Debug.Log("abandon swoop" + (Time.time - startTime));
            stateMachine.ChangeState(mount.idleInAirState);
        }

        else if ((Time.time - startTime) >= mountData.elevationChangeTimeBuffer)
        {
            Debug.Log("dive dive dive");
            stateMachine.ChangeState(mount.elevationChangeInAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (input.y == 0 && (Time.time - startTime) <= mountData.swoopTimeBuffer)
        {
            Debug.Log("swooped");
            mount.controller.EnterSwoop(initialInput);

            mount.transform.position = new Vector3(0,10,0);
        }

        mount.controller.Move(input);
    }
}
