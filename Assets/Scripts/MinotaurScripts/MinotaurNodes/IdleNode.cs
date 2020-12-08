using MinotaurScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class IdleNode : Node
    {
       
        public override NodeState Evaluate()
        {
            GameObject thePlayer = GameObject.Find("Minotaur");
            thePlayer.GetComponent<MinotaurAgro>().stopChasingPlayer();
            
            return NodeState.RUNNING;
        }
    }
}