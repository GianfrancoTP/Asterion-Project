using System;
using System.Net.Mail;
using UnityEngine;
using GhostScript;
namespace PlayerScripts
{
    public class PlayerPowerScript : MonoBehaviour
    {
        private float timeBtwPowerAres;
        public float startTimerBtwPowerAres;
        public Transform attackPosPowerAres;
        public float rangePowerAres;
        public float damagePowerAres;
        public LayerMask whatIsEnemiesPowerAres;
        
        [SerializeField] private PlayerMainScript mainScript;
        internal bool isKilled;

        private void FixedUpdate()
        {
            if (mainScript.inputScript.powerAttack)
            {
                specialPower();
            }
            else if (mainScript.inputScript.utilityAttack)
            {
                Debug.Log("WHAT");
                mainScript.inputScript.utilityAttack = false;
                UtilityPower();
                
            }
        }
        

        void specialPower()
        {
            if (mainScript.houseScript.house == "ARES")
            {
                if (timeBtwPowerAres <= 0)
                {
                    AresPower();
                    mainScript.inputScript.powerAttack = false;
                    timeBtwPowerAres = startTimerBtwPowerAres;
                }
                else
                {
                    timeBtwPowerAres -= Time.deltaTime;
                }
            }
            else if (mainScript.houseScript.house == "HERMES")
            {
                mainScript.inputScript.powerAttack = false;
                mainScript.movementScript.movementSpeed +=5;
                Invoke("HermesPower", 2.0f);                
            }
        }

        void UtilityPower()
        {
            if (mainScript.houseScript.house == "ARES")
            {
                mainScript.inputScript.utilityAttack = false;
                mainScript.houseScript.armor += 5;
                Invoke("HermesUtility", 2.0f);
                Debug.Log("AresUtility");

            }
            else if (mainScript.houseScript.house == "HERMES")
            {
                mainScript.inputScript.utilityAttack = false;
                mainScript.playerAttackScript.startTimerBtwAttack = (float) 0.1;
                Invoke("HermesUtility", 2.0f);        
                Debug.Log("HermUtility");
            }
        }

        void HermesPower()
        {
            mainScript.movementScript.movementSpeed -= 5;
        }

        void HermesUtility()
        {
            mainScript.playerAttackScript.startTimerBtwAttack = (float) 0.5;
        }
        void AresPower()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosPowerAres.position, rangePowerAres, whatIsEnemiesPowerAres);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(damagePowerAres);
               
            }
        }

        void AresUtility()
        {
            mainScript.houseScript.armor -= 5;
        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPosPowerAres.position,rangePowerAres);
        }
    }
}