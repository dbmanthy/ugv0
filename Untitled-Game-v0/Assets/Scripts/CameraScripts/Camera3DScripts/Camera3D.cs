using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraInputHandler))]
public class Camera3D : MonoBehaviour
{
    [SerializeField]
    Transform target;

    CameraInputHandler inputHandler;
    CameraController3D controller;

    Vector2 cameraDelta;

    void Awake()
    {
        inputHandler = GetComponent<CameraInputHandler>();
        controller = new CameraController3D();//TODO: is this even needed? could they just be static methods
    }

    void Start()
    {

    }

    void Update()
    {
        cameraDelta = inputHandler.cameraDelta;

    }
}

