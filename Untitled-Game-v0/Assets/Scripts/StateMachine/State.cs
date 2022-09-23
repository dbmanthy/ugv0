using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    //keep track of what state machine and entity the state belongs to
    protected StateMachine stateMachine;
    protected Entity entity;
    protected ScriptableObject entityData; // TODO: will this work as all data will inherit from entity data??
    protected string animationBoolName;

    protected float startTime;

    public State(Entity entity, StateMachine stateMachine, ScriptableObject entityData, string animationBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.entityData = entityData;
        this.animationBoolName = animationBoolName;
    }

    public virtual void EnterState()
    {
        DoChecks();
        //entity.animator.SetBool(animationBoolName, true); 
        startTime = Time.time;

        //Debug.Log(animationBoolName);
    }

    public virtual void ExitState()
    {
        //entity.animator.SetBool(animationBoolName, false);
    }

    //update
    public virtual void LogicUpdate()
    {

    }

    //fixed update
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //remove before flight : do checks
    public virtual void DoChecks()
    {

    }
}
