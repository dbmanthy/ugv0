using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MountController))]
public class Mount : MonoBehaviour
{
    MountController controller;
    float moveSpeed = 12f;
    float rotationSpeed = 10f;

    void Start()
    {
        controller = GetComponent<MountController>();
    }

    void Update()
    {
        Vector3 horizontalInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 verticalInput = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
        controller.Move(horizontalInput, moveSpeed, rotationSpeed);
        controller.ChangeElevation(verticalInput);
    }
}
