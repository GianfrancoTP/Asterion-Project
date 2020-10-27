using System;
using GhostScript;
using UnityEngine;
using UnityEngine.Rendering;

namespace PlayerScripts
{
    public class PlayerAttackScript : MonoBehaviour
    {
        private float timeBtwAttack;
        public float startTimerBtwAttack;
        public Transform attackPos;
        public float attackRange;
        public float attackDamage;
        public LayerMask whatIsEnemies;
        
        
        
        private float timeBtwPowerAres;
        public float startTimerBtwPowerAres;
        public Transform attackPosPowerAres;
        public float rangePowerAres;
        public float damagePowerAres;
        public LayerMask whatIsEnemiesPowerAres;
        
        
        
        [SerializeField] private PlayerMainScript mainScript;
        internal bool isKilled;
        
        
        void Update()
        {
            if (timeBtwAttack <= 0)
            {
                if (mainScript.inputScript.basicAttack)
                {
                    basicAttack();
                    mainScript.inputScript.basicAttack = false;
                }

                timeBtwAttack = startTimerBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }

            if (mainScript.inputScript.powerAttack)
            {
                specialPower();
            }
        }

        void basicAttack()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    isKilled = enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(attackDamage);
                    if (isKilled)
                    {
                        mainScript.stateScript.AddExperience(10);
                    }
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
                mainScript.movementScript.movementSpeed = 10;
                Invoke("HermesPower", 2.0f);                
            }
        }

        void HermesPower()
        {
            mainScript.movementScript.movementSpeed = 5;
        }

        void AresPower()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosPowerAres.position, rangePowerAres, whatIsEnemiesPowerAres);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                isKilled = enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(damagePowerAres);
                if (isKilled)
                {
                    mainScript.stateScript.AddExperience(10);
                }
            }
        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPosPowerAres.position,rangePowerAres);
        }
    }
}