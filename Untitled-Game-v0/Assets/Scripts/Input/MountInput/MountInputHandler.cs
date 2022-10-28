using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //TODO:not all these are needed.a chancge to be made accross the board

public class MountInputHandler : MonoBehaviour
{
    MountInputActions mountInputActions;

    public Vector2 moveInput { get; private set; }
    public bool yInputHeldDown { get; private set; }
    public InputAction.CallbackContext moveInputContext { get; private set; }

    void Awake()
    {
        mountInputActions = new MountInputActions();
    }

    void OnEnable()
    {
        //subscribe function to action
        mountInputActions.Flying.Movement.performed += OnMoveInput;
        mountInputActions.Flying.Movement.Enable();
        //mountInputActions.Flying.Movement.performed += OnJumpInput;

        mountInputActions.Flying.Jump.performed += OnJumpInput;
        mountInputActions.Flying.Jump.Enable();
    }

    void OnDisable()
    {
        mountInputActions.Flying.Movement.Disable();
        mountInputActions.Flying.Jump.Disable();

        //TODO: add a on being lifted up?? method subscription??s -> then have nodes store input 
    }

    //input system takes care of normalizing input
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveInputContext = context;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started && moveInput.y != 0)
        {
            yInputHeldDown = true;
        }
        else
        {
            yInputHeldDown = false;
        }
    }
}
