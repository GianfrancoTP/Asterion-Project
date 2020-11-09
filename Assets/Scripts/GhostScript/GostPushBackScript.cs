using System;
using UnityEngine;

namespace GhostScript
{
    public class GostPushBackScript : MonoBehaviour
    {
        [SerializeField] private GhostMainScript mainScript;

        private void Start()
        {
            GhostStateScript.GhostDamage += pushBack;
        }

        void pushBack()
        {
            
        }
    }
}