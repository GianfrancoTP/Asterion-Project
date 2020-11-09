﻿using UnityEngine;

namespace GhostScript
{
    public class GhostMainScript : MonoBehaviour
    {
        [SerializeField] internal GhostMovementScript movementScript;
        [SerializeField] internal GhostStateScript stateScript;

        private void Awake()
        {
            
        }
    }
}