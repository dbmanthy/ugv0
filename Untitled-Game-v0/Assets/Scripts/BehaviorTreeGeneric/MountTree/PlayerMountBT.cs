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

    void Awake()
    {
        mountController = GetComponent<PlayerMountController>();
        inputHandler = GetComponent<MountInputHandler>();
    }

    //protected override BehaviorNode PlantTree()
    //{
    //    BehaviorNode root = new FallbackNode(new List<BehaviorNode>
    //    {
    //        new SequenceNode(new List<BehaviorNode>
    //        {
    //            new MoveInputCheck(inputHandler),
    //            new BankNode(transform, mountController, mountData)
    //        }),
    //        new IdleFlyNode(transform, mountController, mountData)
    //    });
    //    return root;
    //}
    protected override BehaviorNode PlantTree()
    {
        BehaviorNode root = new FallbackNode(new List<BehaviorNode>
        {
            //bank
            new SequenceNode(new List<BehaviorNode>
            {
                new MoveInputCheck(inputHandler),
                new BankNode(transform, mountController, mountData)
            }),
            //swoop
            new SequenceNode(new List<BehaviorNode>
            {
                new SwoopInputCheck(inputHandler),
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
    public static readonly string magnitude = "Magnitude";
}