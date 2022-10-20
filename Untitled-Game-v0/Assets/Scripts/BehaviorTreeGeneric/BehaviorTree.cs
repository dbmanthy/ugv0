using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeBehaviour
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        BehaviorNode root = null;

        protected void Start()
        {
            root = PlantSBTree();
        }

        void Update()
        {
            if(root!= null)
            {
                root.EvaluateNode();
            }
        }

        protected abstract BehaviorNode PlantSBTree();
    }
}
