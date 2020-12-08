using MinotaurScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class ChaseNode : Node
    {
        public override NodeState Evaluate()
        {
            GameObject thePlayer = GameObject.Find("Minotaur");
            thePlayer.GetComponent<MinotaurAgro>().chasePlayer();
            
            
            return NodeState.RUNNING;
        }
    }
}