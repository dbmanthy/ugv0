using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //TODO:not all these are needed.a chancge to be made accross the 

public class MountInputHandler : MonoBehaviour
{
    MountInputActions mountInputActions;

    //move
    public InputAction.CallbackContext moveInputContext { get; private set; }
    public Vector2 moveInput { get; private set; }

    //attack
    public bool attackInput { get; private set; }

    //swoop
    public float swoopInputTime { get; private set; }
    public int swoopInput { get; private set; }
    public bool swoopInputPressed { get; private set; }
    float swoopStartTime;

    void Awake()
    {
        mountInputActions = new MountInputActions();
    }

    void OnEnable()
    {
        //subscribe function to action
        mountInputActions.Flying.Movement.started += OnSwoopInputDown;
        mountInputActions.Flying.Movement.performed += OnMoveInput; // this is performed so the functions are called when the action is perfromed!! canchange this to started
        mountInputActions.Flying.Movement.canceled += OnSwoopInputUp;
        mountInputActions.Flying.Movement.Enable();

        mountInputActions.Flying.Attack.performed += OnAttackInput;
        mountInputActions.Flying.Attack.Enable();
    }

    void OnDisable()
    {
        mountInputActions.Flying.Movement.Disable();
        mountInputActions.Flying.Attack.Disable();

        //TODO: add a on being lifted up?? method subscription??s -> then have nodes store input 
    }

    //input system takes care of normalizing input
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>input " + moveInput);
        moveInputContext = context;
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            attackInput = true;
        }
    }

    public void UseAttackInput()
    {
        attackInput = false;
    }

    public void OnSwoopInputDown(InputAction.CallbackContext context)
    {
        if (context.started && moveInput.y != 0)
        {
            swoopInput = (int)moveInput.y; // input is automatically normilized
            swoopInputPressed = true;
            swoopStartTime = Time.time;
        }
    }

    public void OnSwoopInputUp(InputAction.CallbackContext context)
    {
        if (swoopInputPressed)
        {
            swoopInputTime = Time.time - swoopStartTime;
            swoopInputPressed = false;
            swoopStartTime = 0f;
        }
    }
}
