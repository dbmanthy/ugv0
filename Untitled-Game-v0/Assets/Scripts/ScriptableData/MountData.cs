using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "newMountData", menuName = "Data/Mount Data/Base Data")]
public class MountData : ScriptableObject
{
    //velocity is to be thought of as relative to the mount as it will be more efficient to calculate adding velcoities in the appropriate ways from actions rather than rotating the velocity every frame
    public Vector3 localVelocity = Vector3.zero;

    [Header("IdleInAir")]
    public float initialMoveSpeed = 26f;

    [Header("BankingInAir")]
    public float minRotate = -50f;
    public float maxRotate = 50f;
    public float yawLerpRate = .1f;
    public float outRollLerpRate = .5f;
    public float inRollLerpRate = .22f;
    public float rotationSpeed = 10f;

    [Header("SwoopingInAir")]
    public float swoopDistance = 30f;
}