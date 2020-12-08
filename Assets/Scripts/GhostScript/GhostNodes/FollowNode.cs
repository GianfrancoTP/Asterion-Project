using GhostScript;
using MinotaurScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class FollowNode : Node
    {
        private GameObject ghost;

        public FollowNode(GameObject ghost)
        {
            this.ghost = ghost;
        }
        public override NodeState Evaluate()
        {
            
            ghost.GetComponent<GhostAgroScript>().chasePlayer();
            
            
            return NodeState.RUNNING;
        }
    }
}