using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

[RequireComponent(typeof(PlayerMountController))]
[RequireComponent(typeof(MountInputHandler))]

public class PlayerMountBT : BehaviorTree
{
    public PlayerMountData mountData;

    PlayerMountController mountController;
    MountInputHandler inputHandler;

    protected override void Start()
    {
        mountController = GetComponent<PlayerMountController>();
        inputHandler = GetComponent<MountInputHandler>();

        base.Start();
    }

    protected override BehaviorNode PlantTree()
    {
        BehaviorNode root = new FallbackNode(new List<BehaviorNode>
        {
            new PlayerMountIdleNode(transform, mountController, mountData)
        });
        return root;
    }
}
