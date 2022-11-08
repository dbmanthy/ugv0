using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeBehaviour;

public class MoveNodePlayer : BehaviorNode
{
    Transform transform;
    Transform cameraTransform;
    PlayerController3D controller3D;

    public MoveNodePlayer(Transform transform, Transform cameraTransform,PlayerController3D controller3D)
    {
        this.transform = transform;
        this.cameraTransform = cameraTransform;
        this.controller3D = controller3D;
    }

    public override BehaviorState LogicUpdate()
    {
        float magnitude;
        root = GetRoot();
        
        object tInput = root.GetData(DataLabels.moveInput);
        if(tInput == null)
        {
            Debug.Log("::WARNING:: MoveNodePlayer recieved null input. This should not be possible: MoveInputCheckPlayer should catch this");
            nodeState = BehaviorState.FAILURE;
            return nodeState;
        }

        Vector2 input = (Vector2)tInput;
        Vector3 inputDirection = controller3D.InputToMoveDirection(input, cameraTransform);

        object tVelocity = root.GetData(DataLabels.velocity);
        if (tVelocity == null)
        {
            Debug.Log("::WARNING:: MoveNodePlayer recieved null velocity");
            tVelocity = Vector3.zero;
            magnitude = 10f;
        }

        Vector3 velocity = (Vector3)tVelocity;
        velocity.x = inputDirection.x;
        velocity.z = inputDirection.z;
        magnitude = velocity.magnitude;
        velocity.Normalize();
        velocity *= magnitude;

        root.SetData(DataLabels.velocity, velocity);
        controller3D.Move(transform, velocity);

        nodeState = BehaviorState.SUCCESS;
        return nodeState;
    }
}
