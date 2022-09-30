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
}