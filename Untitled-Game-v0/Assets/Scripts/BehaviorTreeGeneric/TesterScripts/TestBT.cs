using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TreeBehaviour;

public class TestBT : BehaviorTree
{
    public static float moveSpeed = 10f;
    public static float raycastDist = 20f;
    public static float theta = 10f;

    protected override BehaviorNode PlantTree()
    {
        BehaviorNode root = new FallbackNode(new List<BehaviorNode>
        {
            new SequenceNode(new List<BehaviorNode>
            {
                new CollisionCheck(transform),
                new FindNewHeading(transform)
            }),
            new Move(transform)
        });
        return root;
    }
}
