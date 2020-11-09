using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerInputScript : MonoBehaviour
    {
        internal Vector3 change;
        internal bool basicAttack;
        internal bool powerAttack;
        internal bool utilityAttack;

        [SerializeField] private PlayerMainScript mainScript;
        public static event Action Attac;
        private void Update()
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                basicAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                powerAttack = true;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                utilityAttack = true;
            }
        }
    }
}