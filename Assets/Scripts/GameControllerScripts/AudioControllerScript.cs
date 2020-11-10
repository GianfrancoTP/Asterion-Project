using System;
using MinotaurScripts;
using PlayerScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class AudioControllerScript : MonoBehaviour
    {
        public static AudioClip minotaurStun, playerAttack, winSound, objectSound, damageSound, ghostDeathSound, ghostDamaged, minotaurDamaged;
        static AudioSource audioSrc;

        void Start()
        {
            ghostDamaged = Resources.Load<AudioClip>("GhostDamage");
            minotaurDamaged = Resources.Load<AudioClip>("MinotaurDamage");
            ghostDeathSound = Resources.Load<AudioClip>("GhostDeath");
            damageSound = Resources.Load<AudioClip>("DamageTaken");
            objectSound = Resources.Load<AudioClip>("ObjectSound");
            winSound = Resources.Load<AudioClip>("WinSound");
            minotaurStun = Resources.Load<AudioClip>("StunSound");
            playerAttack = Resources.Load<AudioClip>("SlashSound");
            PlayerHealthScript.takeDamage += PlayerDamageSound;
            MinotaurState.MinotaurStun += MinautorStunSound;

            audioSrc = GetComponent<AudioSource>();
        }

        public static void  PlayerDamageSound()
        {
            audioSrc.PlayOneShot(damageSound);
        }

        public static void PlayerAttackSound()
        {
            audioSrc.PlayOneShot(playerAttack);
        }

        public static void GhostDeathSound()
        {
            audioSrc.PlayOneShot(ghostDeathSound);
        }

        public static void MinautorStunSound()
        {
            audioSrc.PlayOneShot(minotaurStun);
        }

        public static void TakeObjectSound() 
        {
            audioSrc.PlayOneShot(objectSound);
        }

        public static void EnterDoorSound()
        {
            audioSrc.PlayOneShot(winSound);
        }

        public static void GhostDamaged() 
        {
            audioSrc.PlayOneShot(ghostDamaged);   
        }

        public static void MinotaurDamaged()
        {
            audioSrc.PlayOneShot(minotaurDamaged);
        }
    }
}