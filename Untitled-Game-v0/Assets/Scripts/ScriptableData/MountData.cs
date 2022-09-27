using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "newMountData", menuName = "Data/Mount Data/Base Data")]
public class MountData : ScriptableObject
{
    [Header("IdleInAir")]
    
    public float yawLerpRate = .1f;
    public float outRollLerpRate = .5f;
    public float inRollLerpRate = .22f;
    public float diveSpeed = 10f;
    public float climbSpeed = 4f;

    [Header("BankingInAir")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 6f;

    public float minRotate = -50f;
    public float maxRotate = 50f;
}
 