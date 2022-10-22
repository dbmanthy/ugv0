using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeBehaviour
{
    public class SequenceNode : BehaviorNode
    {
        public SequenceNode(): base() { }
        public SequenceNode(List<BehaviorNode> children): base(children) { }

        public override BehaviorState LogicUpdate()
        {
            bool childRunning = false;

            foreach(BehaviorNode node in children)
            {
                switch(node.LogicUpdate())
                {
                    case BehaviorState.RUNNING:
                        childRunning = true;
                        continue;
                    case BehaviorState.SUCCESS:
                        continue;
                    case BehaviorState.FAILURE:
                        nodeState = BehaviorState.FAILURE;
                        return nodeState;
                    default:
                        nodeState = BehaviorState.SUCCESS;
                        return nodeState;
                }
            }
            nodeState = childRunning ? BehaviorState.RUNNING : BehaviorState.SUCCESS;
            return nodeState;
        }
    }
}
