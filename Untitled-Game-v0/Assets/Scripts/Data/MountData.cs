using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "newMountData", menuName = "Data/Mount Data/Base Data")]
public class MountData : ScriptableObject
{

    [Header("BaseMovement")]
    public Vector3 velocity = Vector3.forward * 20;
    public float rotationSpeed = 10f;
    public float movementSpeed = 26f;
    public float baseMovementSpeed = 26f;

    [Header("IdleInAir")]


    [Header("BankingInAir")]
    public float minRotate = -50f;
    public float maxRotate = 50f;
    public float yawLerpRate = .1f;
    public float outRollLerpRate = .5f;
    public float inRollLerpRate = .22f;
    

    [Header("SwoopingInAir")]
    public float swoopDistance = 30f;
    public float swoopDamping = 30f;
    public float swoopTimeBuffer = .5f;
    public float elevationChangeTimeBuffer = 2f;

    //TODO: find a better place for this
    [Header("GloablWolrdData")]
    public float worldBaseHeight = 0f;
    public float worldUpperHeight = 300f;
    public float worldMiddleHeight = 150f;

    [Header("ElevationChangeInAir")]
    public bool enRoute = false;

}