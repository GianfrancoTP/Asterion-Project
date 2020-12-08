using MinotaurScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class IsNearNode : Node
    {
        private bool isNear;

        public override NodeState Evaluate()
        {
            
            GameObject thePlayer = GameObject.Find("Minotaur");
            isNear = thePlayer.GetComponent<MinotaurAgro>().isMinotaurClose;
            //Vector3 offset = rat.transform.position - player.transform.position;
            //float sqrLen = offset.sqrMagnitude;

            // square the distance we compare with
            //if (sqrLen < threshold * threshold)
            if (isNear)
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