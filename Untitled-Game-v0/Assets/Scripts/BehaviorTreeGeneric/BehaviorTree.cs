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
                //Tick
                root.LogicUpdate();
            }
        }

        //void FixedUpdate()
        //{
        //    if (root != null)
        //    {
        //        Debug.Log("Update(" + root.name + ")");
        //        root.PhysicsUpdate();
        //    }
        //}

        protected abstract BehaviorNode PlantSBTree();
    }
}
