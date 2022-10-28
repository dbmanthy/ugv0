using System.Collections;
using System.Collections.Generic;

namespace TreeBehaviour
{
    public enum BehaviorState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class BehaviorNode
    {
        protected BehaviorState nodeState;
        protected List<BehaviorNode> children = new List<BehaviorNode>();

        public BehaviorNode root;
        public BehaviorNode parent;

        Dictionary<string, object> sharedTreeData = new Dictionary<string, object>();

        public BehaviorNode()
        {
            parent = null;
            root = this;
        }

        public BehaviorNode(List<BehaviorNode> _children)
        {
            foreach(BehaviorNode child in _children)
            {
                AttachChild(child);
            }
        }

        void AttachChild(BehaviorNode node)
        {
            node.parent = this;
            node.root = GetRoot(); //some how this doesnt work ... 
            children.Add(node);

        }

        public virtual BehaviorState LogicUpdate()
        {
            return BehaviorState.FAILURE;
        }

        public BehaviorNode GetRoot()
        {
            BehaviorNode root = this;

            while(root.parent != null)
            {
                root = root.parent;
            }
            return root;
        }

        public void SetData(string key, object value)
        {
            sharedTreeData[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            BehaviorNode node = parent;

            if (sharedTreeData.TryGetValue(key, out value))
                return value;
            
            while(node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            BehaviorNode node = parent;

            if (sharedTreeData.ContainsKey(key))
            {
                sharedTreeData.Remove(key);
                return true;
            }

            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }
    }
}
