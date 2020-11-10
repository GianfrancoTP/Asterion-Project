using System;
using DefaultNamespace;
using GhostScript;
using MinotaurScripts;
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

        public static event Action PlayerAttack;
        
        void Update()
        {
            if (timeBtwAttack <= 0)
            {
                if (mainScript.inputScript.basicAttack)
                {
                    PlayerAttack?.Invoke();
                    //AudioControllerScript.PlayerAttackSound();
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
                    if (enemiesToDamage[i].gameObject.tag == "Ghost")
                    {
                        enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(attackDamage);
                        

                    }
                    else if (enemiesToDamage[i].gameObject.tag == "Minotaur")
                    {
                        enemiesToDamage[i].GetComponent<MinotaurMainScript>().stateScript.TakeDamage(attackDamage);

                    }
                    
                }
                
        }

       
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }
    }
}