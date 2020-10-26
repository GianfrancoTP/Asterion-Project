using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerInputScript : MonoBehaviour
    {
        internal Vector3 change;
        internal bool basicAttack;
        internal bool powerAttack;

        [SerializeField] private PlayerMainScript mainScript;
    
        private void Update()
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            
            if (Input.GetKey(KeyCode.E))
            {
                basicAttack = true;
            }
            if (Input.GetKey(KeyCode.R))
            {
                powerAttack = true;
            }
        }
    }
}