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
        }

        void basicAttack()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(attackDamage);
                }
                
        }

       
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }
    }
}