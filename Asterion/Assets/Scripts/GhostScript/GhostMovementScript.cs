﻿using UnityEngine;

namespace GhostScript
{
    public class GhostMovementScript : MonoBehaviour
    {
        public float movementSpeed = 5;

        [SerializeField] private GhostMainScript mainScript;

        private void FixedUpdate()
        {
            Patrol();
        }
        
        void Patrol()
        {
            if (mainScript.stateScript._goingUp)
            {
                transform.Translate(movementSpeed * Time.deltaTime * Vector3.up);
            }
            else
            {
                transform.Translate(movementSpeed * Time.deltaTime * Vector3.down);
            }

            
        }
    }
}