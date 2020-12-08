using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace GhostScript
{
    public class GhostBehaviourScript : MonoBehaviour
    {
        private Node topNode;
        //public GameObject player;
        private void ContructDecisionTree()
        {
            FollowNode followNode = new FollowNode(this.gameObject);
            IsNearPlayerNode  isPlayerNearNode= new IsNearPlayerNode(this.gameObject);
            RoamNode roamingNode = new RoamNode(this.gameObject);

            Sequence ChaseSequece = new Sequence(new List<Node> {isPlayerNearNode, followNode});
            Sequence RoamSequence = new Sequence(new List<Node> {new Inverter(isPlayerNearNode), roamingNode});
            
            topNode = new Selector(new List<Node>(){RoamSequence,ChaseSequece});

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