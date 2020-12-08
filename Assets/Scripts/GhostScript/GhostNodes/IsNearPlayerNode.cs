using GhostScript;
using MinotaurScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class IsNearPlayerNode : Node
    {
        private GameObject ghost;

        public IsNearPlayerNode(GameObject ghost)
        {
            this.ghost = ghost;
        }
        public override NodeState Evaluate()
        {
            
            //Vector3 offset = rat.transform.position - player.transform.position;
            //float sqrLen = offset.sqrMagnitude;

            // square the distance we compare with
            //if (sqrLen < threshold * threshold)
            if (ghost.GetComponent<GhostAgroScript>().isGhostClose)
            {
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }
}