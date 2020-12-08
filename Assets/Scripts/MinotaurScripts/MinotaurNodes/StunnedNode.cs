using MinotaurScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class StunnedNode : Node
    {
        private bool isStuned;

        public override NodeState Evaluate()
        {
            
            GameObject thePlayer = GameObject.Find("Minotaur");
            isStuned = thePlayer.GetComponent<MinotaurState>().stuned;
            //Vector3 offset = rat.transform.position - player.transform.position;
            //float sqrLen = offset.sqrMagnitude;

            // square the distance we compare with
            //if (sqrLen < threshold * threshold)
            if (isStuned)
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