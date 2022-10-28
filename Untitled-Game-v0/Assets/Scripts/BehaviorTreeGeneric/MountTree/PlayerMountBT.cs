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

    //TODO: can replace start with awake? remove start inheritance?
    void Awake()
    {
        mountController = GetComponent<PlayerMountController>();
        inputHandler = GetComponent<MountInputHandler>();
    }

    //protected override void Start()
    //{
    //    mountController = GetComponent<PlayerMountController>();
    //    inputHandler = GetComponent<MountInputHandler>();

    //    base.Start();
    //}

    protected override BehaviorNode PlantTree()
    {
        BehaviorNode root = new FallbackNode(new List<BehaviorNode>
        {
            new SequenceNode(new List<BehaviorNode>
            {
                new InputCheck(inputHandler),
                new BankNode(transform, mountController, mountData)
            }),
            new IdleFlyNode(transform, mountController, mountData)
        });
        return root;
    }
}

public static class DataLabels
{
    public static readonly string bankInput = "BankInput";
    public static readonly string velocity = "Velocity";
}