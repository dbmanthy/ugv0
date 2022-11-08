using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerInputActions inputActions;

    public Vector2 moveInput { get; private set; }
    public bool activeMoveInput { get; private set; }
    public bool jumpInput { get; private set; }

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        //WASD
        inputActions.Grounded.Movement.performed += OnMoveInput; // need to use performed not started. If you started doesn't pick up on if two keys are being pressed at the same time
        inputActions.Grounded.Movement.canceled += OnMoveInputStop;
        inputActions.Grounded.Movement.Enable();

        //SPACE
        inputActions.Grounded.Jump.performed += OnJumpInput;
        inputActions.Grounded.Jump.Enable();
    }

    void OnDisable()
    {
        inputActions.Grounded.Movement.Disable();
        inputActions.Grounded.Jump.Disable();
    }

    void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();//input system takes care of normalizing input
        Debug.Log("input " + moveInput);
        activeMoveInput = true;
    }

    void OnMoveInputStop(InputAction.CallbackContext context)
    {
        activeMoveInput = false;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("jumpers");
            jumpInput = true;
        }
    }

    public void UseJumpInput()
    {
        jumpInput = false;
    }
}