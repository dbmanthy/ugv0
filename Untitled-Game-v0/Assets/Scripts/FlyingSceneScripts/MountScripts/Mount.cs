using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MountInputHandler))]
[RequireComponent(typeof(MountController))]//holds funcitons for the mountsd
[RequireComponent(typeof(MountCameraController))]

public class Mount : Entity
{
    //set states
    public Idle_InAirState idleInAirState { get; private set; }
    public Banking_InAirState bankingInAirState { get; private set; }
    public Climbing_InAirState climbingInAirState { get; private set; }
    public Diving_InAirState divingInAirState { get; private set; }

    public MountInputHandler inputHandler { get; private set; }
    public MountController controller { get; private set; }

    //[SerializeField]
    //public MountData mountData;

    public override void Awake()
    {
        base.Awake();

        //dont need to create super states
        controller = GetComponent<MountController>();
        idleInAirState = new Idle_InAirState(this, stateMachine, entityData, "IdleInAir", this);
        bankingInAirState = new Banking_InAirState(this, stateMachine, entityData, "BankingInAir", this);
        climbingInAirState = new Climbing_InAirState(this, stateMachine, entityData, "BankingInAir", this);
        divingInAirState = new Diving_InAirState(this, stateMachine, entityData, "BankingInAir", this);
    }

    public override void Start()
    {
        base.Start();
        stateMachine.InitializeStateMachine(idleInAirState);
        //states have reference to entity and entity has reference to input handler so by the transitive property ..
        inputHandler = GetComponent<MountInputHandler>();
        
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
