using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputHandler : MonoBehaviour
{
    CameraInputActions inputActions;

    public Vector2 cameraDelta { get; private set; }

    void Awake()
    {
        inputActions = new CameraInputActions();
    }

    void OnEnable()
    {
        inputActions.PlayerCamera.Look.performed += OnCameraDelta;
        inputActions.PlayerCamera.Enable();
    }

    void OnDisable()
    {
        inputActions.PlayerCamera.Disable();
    }

    void OnCameraDelta(InputAction.CallbackContext context)
    {
        cameraDelta = context.ReadValue<Vector2>();
        Debug.Log(cameraDelta  + " delta");
    }
}
