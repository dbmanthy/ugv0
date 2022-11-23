using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeBehaviour;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerBT : BehaviorTree
{
    [SerializeField]
    Camera playCamera;

    PlayerInputHandler inputHandler;
    PlayerController3D controller3D;
    void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        controller3D = new PlayerController3D();
    }

    protected override BehaviorNode PlantTree()
    {
        BehaviorNode root = new FallbackNode(new List<BehaviorNode>
        {
            //movement
            new SequenceNode(new List<BehaviorNode>
            {
                new MoveInputCheckPlayer(inputHandler),
                new MoveNodePlayer(transform, playCamera.transform, controller3D)
            }),
            new PlayerDebugNode()
        });
        
        return root;
    }
}
