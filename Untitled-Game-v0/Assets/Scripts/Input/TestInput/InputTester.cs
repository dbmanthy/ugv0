using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTester : MonoBehaviour
{
    TestInput testInput;

    void Awake()
    {
        testInput = new TestInput();
    }

    void OnEnable()
    {
        testInput.General.Space.performed += LogInput;
        testInput.General.Space.Enable();
    }

    void OnDisable()
    {
        testInput.General.Space.Disable();
    }

    public void LogInput(InputAction.CallbackContext context)
    {
        Debug.Log("input received !!");
    }
}
