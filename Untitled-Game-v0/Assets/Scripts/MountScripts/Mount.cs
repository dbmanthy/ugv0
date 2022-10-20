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
    public Swooping_InAirState swoopingInAirState { get; private set; }
    public ElevationChange_InAirState elevationChangeInAirState { get; private set; }
    public TakeFlight_InAirSate takeFligthInAirState { get; private set; }

    //dependencies
    public MountInputHandler inputHandler { get; private set; }
    public MountController controller { get; private set; }

    //[SerializeField]
    //public MountData mountData;

    public override void Awake()
    {
        base.Awake();

        controller = GetComponent<MountController>();
        //states have reference to entity and entity has reference to input handler so by the transitive property ..
        inputHandler = GetComponent<MountInputHandler>();
    }

    public override void Start()
    {
        base.Start();

        //dont need to create super states
        takeFligthInAirState = new TakeFlight_InAirSate(this, stateMachine, entityData, "TakeFlightInAir", this);
        idleInAirState = new Idle_InAirState(this, stateMachine, entityData, "IdleInAir", this);
        bankingInAirState = new Banking_InAirState(this, stateMachine, entityData, "BankingInAir", this);
        swoopingInAirState = new Swooping_InAirState(this, stateMachine, entityData, "SwoopingInAir", this);
        elevationChangeInAirState = new ElevationChange_InAirState(this, stateMachine, entityData, "SwoopingInAir", this);

        //must happen after state declaration
        stateMachine.InitializeStateMachine(takeFligthInAirState);
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
