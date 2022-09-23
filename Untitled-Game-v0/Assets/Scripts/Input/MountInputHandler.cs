using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MountInputHandler : MonoBehaviour
{
    public Vector2 bankInput { get; private set; }

    //input system takes care of normalizing input
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        bankInput = context.ReadValue<Vector2>();
    }
}
