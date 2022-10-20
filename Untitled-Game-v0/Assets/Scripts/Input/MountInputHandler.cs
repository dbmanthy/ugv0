using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MountInputHandler : MonoBehaviour
{
    public Vector2 controllerInput { get; private set; }
    //public InputAction.CallbackContext controllerInputContext { get; private set; }

    public bool yInputHeldDown { get; private set; }

    //input system takes care of normalizing input
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        controllerInput = context.ReadValue<Vector2>();
        //controllerInputContext = context;

        if (context.started && controllerInput.y != 0)
        {
            yInputHeldDown = true;
        }
        else
        {
            yInputHeldDown = false;
        }
    }
}
