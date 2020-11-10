using System;
using GhostScript;
using MinotaurScripts;
using PlayerScripts;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class AudioControllerScript : MonoBehaviour
    {
        public static AudioClip minotaurStun, playerAttack, winSound, objectSound, damageSound, ghostDeathSound, ghostDamaged, minotaurDamaged, levelUp, specialSound, aresHit;
        static AudioSource audioSrc;

        void Start()
        {
            specialSound = Resources.Load<AudioClip>("SpecialAttack");
            aresHit = Resources.Load<AudioClip>("AresSpecial");
            levelUp = Resources.Load<AudioClip>("LevelUpSound");
            ghostDamaged = Resources.Load<AudioClip>("GhostDamage");
            minotaurDamaged = Resources.Load<AudioClip>("MinotaurDamage");
            ghostDeathSound = Resources.Load<AudioClip>("GhostDeath");
            damageSound = Resources.Load<AudioClip>("DamageTaken");
            objectSound = Resources.Load<AudioClip>("ObjectSound");
            winSound = Resources.Load<AudioClip>("WinSound");
            minotaurStun = Resources.Load<AudioClip>("StunSound");
            playerAttack = Resources.Load<AudioClip>("SlashSound");
            PlayerHealthScript.takeDamage += PlayerDamageSound;
            MinotaurState.MinotaurStun += MinotaurStunSound;
            MinotaurState.MinotaurDamage += MinotaurDamaged;
            PlayerAttackScript.PlayerAttack += PlayerAttackSound;
            PlayerCollisionScript.TakeObject += TakeObjectSound;
            PlayerCollisionScript.EnterDoor += EnterDoorSound;
            PlayerStateScript.LevelUp += LevelUpSound;
            PlayerPowerScript.AresSpecial += AresSpecial;
            PlayerPowerScript.HermesSpecial += HermesSpecial;
            GhostStateScript.GhostDamage += GhostDamaged;
            GhostStateScript.GhostDeath += GhostDeathSound;
            PlayerPowerScript.AresUtil += MinotaurStunSound;

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

        public static void LevelUpSound() 
        {
            audioSrc.PlayOneShot(levelUp);
        }

        public static void HermesSpecial() 
        {
            audioSrc.PlayOneShot(specialSound);
        }

        public static void AresSpecial()
        {
            audioSrc.PlayOneShot(aresHit);
        }

        public static void GhostDeathSound(string ghost)
        {
            audioSrc.PlayOneShot(ghostDeathSound);
        }

        public static void MinotaurStunSound()
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