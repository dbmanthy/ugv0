using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeBehaviour
{
    public class FallbackNode : BehaviorNode
    {
        public FallbackNode() : base() { }
        public FallbackNode(List<BehaviorNode> children) : base(children) { }

        public override BehaviorState LogicUpdate()
        {
            foreach (BehaviorNode node in children)
            {
                switch (node.LogicUpdate())
                {
                    case BehaviorState.RUNNING:
                        nodeState = BehaviorState.RUNNING;
                        return nodeState;
                    case BehaviorState.SUCCESS:
                        nodeState = BehaviorState.SUCCESS;
                        return nodeState;
                    case BehaviorState.FAILURE:
                        continue;
                    default:
                        continue;
                }
            }
            nodeState = BehaviorState.FAILURE;
            return nodeState;
        }
    }
}

