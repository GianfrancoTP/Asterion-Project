using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
namespace MinotaurScripts
{
    public class MinotaurBehaviourScript : MonoBehaviour
    {
        private Node topNode;
        //public GameObject player;
        private void ContructDecisionTree()
        {
            IsNearNode isPlayerNearNode = new IsNearNode();
            IdleNode idleNode = new IdleNode();
            ChaseNode chaseNode = new ChaseNode();

            Sequence ChaseSequece = new Sequence(new List<Node> {isPlayerNearNode, chaseNode});
            Sequence IdleSequence = new Sequence(new List<Node> {new Inverter(isPlayerNearNode), idleNode});
            
            topNode = new Selector(new List<Node>(){IdleSequence,ChaseSequece});

        }

        private void Start()
        {
            ContructDecisionTree();
        }

        private void Update()
        {
            topNode.Evaluate();
            if(topNode.nodeState == NodeState.FAILURE)
            {
                Debug.Log("idle");
            }
        }
    }
}
