using GhostScript;
using UnityEngine;

namespace DefaultNamespace
{
    public class RoamNode : Node
    {
        private GameObject ghost;

        public RoamNode(GameObject ghost)
        {
            this.ghost = ghost;
        }
        public override NodeState Evaluate()
        {
            
            ghost.GetComponent<GhostMovementScript>().Patrol();

            return NodeState.RUNNING;
        }
    }
}