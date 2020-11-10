using System;
using MinotaurScripts;
using PlayerScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class AudioControllerScript : MonoBehaviour
    {
        private void Start()
        {
            PlayerHealthScript.takeDamage += PlayerDamageSound;
            MinotaurState.MinotaurStun += MinautorStunSound;
        }

        void PlayerDamageSound()
        {
            Debug.Log("do sound");
        }

        void PlayerAttackSound()
        {
            
        }

        void GhostDeathSound()
        {
            
        }

        void MinautorStunSound()
        {
            
        }

        void TakeObjectSound()
        {
            
        }

        void EnterDoorSound()
        {
            
        }


    }
}