using System;
using System.Net.Mail;
using UnityEngine;
using GhostScript;
using DefaultNamespace;
using MinotaurScripts;
using UnityEngine.Experimental.Rendering.Universal;

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
        
        private float timeBtwPowerZeus;
        public float startTimerBtwPowerZeus;
        public Transform attackPosPowerZeus;
        public Vector2 rangePowerZeus;
        public float damagePowerZeus;
        public LayerMask whatIsEnemiesPowerZeus;

        public GameObject pointLight;
        
        
        [SerializeField] private PlayerMainScript mainScript;
        public static event Action AresSpecial;
        public static event Action HermesSpecial;
        public static event Action AresUtil;
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
                    AresSpecial?.Invoke();
                    AresPower();
                    mainScript.inputScript.powerAttack = false;
                    timeBtwPowerAres = startTimerBtwPowerAres;
                }
                else
                {
                    timeBtwPowerAres -= Time.deltaTime;
                }
            }

            else if (mainScript.houseScript.house == "ZEUS")
            {
                if (timeBtwPowerZeus <= 0)
                {
                    ZeusPower();
                    mainScript.inputScript.powerAttack = false;
                    timeBtwPowerZeus = startTimerBtwPowerZeus;
                }
                else
                {
                    timeBtwPowerZeus -= Time.deltaTime;
                }
            }
            else if (mainScript.houseScript.house == "HERMES")
            {
                HermesSpecial?.Invoke();
                //AudioControllerScript.SpecialSound();
                mainScript.inputScript.powerAttack = false;
                mainScript.movementScript.movementSpeed +=5;
                Invoke("HermesPower", 2.0f);                
            }
        }

        void UtilityPower()
        {
            if (mainScript.houseScript.house == "ARES")
            {
                AresUtil?.Invoke();
                mainScript.inputScript.utilityAttack = false;
                mainScript.houseScript.armor += 5;
                Invoke("AresUtility", 2.0f);
                Debug.Log("AresUtility");

            }
            else if (mainScript.houseScript.house == "HERMES")
            {
                HermesSpecial?.Invoke();
                mainScript.inputScript.utilityAttack = false;
                mainScript.playerAttackScript.startTimerBtwAttack = (float) 0.1;
                Invoke("HermesUtility", 2.0f);        
                Debug.Log("HermUtility");
            }
            else if (mainScript.houseScript.house == "ZEUS")
            {
                mainScript.inputScript.utilityAttack = false;
                ZeusUtilitty();
                Invoke("ZeusUtilityReturn", 2.0f);        
                Debug.Log("ZeusUT");
            }
        }

        void ZeusPower()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosPowerZeus.position, rangePowerZeus, whatIsEnemiesPowerZeus);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].gameObject.tag == "Ghost")
                {
                    enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(damagePowerZeus);
                        

                }
                else if (enemiesToDamage[i].gameObject.tag == "Minotaur")
                {
                    enemiesToDamage[i].GetComponent<MinotaurMainScript>().stateScript.TakeDamage(damagePowerZeus);

                }
               
            }
            
        }

        void ZeusUtilitty()
        {
            pointLight.GetComponent<Light2D>().pointLightOuterRadius += 5;
            pointLight.GetComponent<Light2D>().pointLightInnerRadius += 5;

            
        }

        void ZeusUtilityReturn()
        {
            pointLight.GetComponent<Light2D>().pointLightOuterRadius -= 5;
            pointLight.GetComponent<Light2D>().pointLightInnerRadius -= 5;
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
                if (enemiesToDamage[i].gameObject.tag == "Ghost")
                {
                    enemiesToDamage[i].GetComponent<GhostMainScript>().stateScript.TakeDamage(damagePowerAres);
                        

                }
                else if (enemiesToDamage[i].gameObject.tag == "Minotaur")
                {
                    enemiesToDamage[i].GetComponent<MinotaurMainScript>().stateScript.TakeDamage(damagePowerAres);

                }
               
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
            
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(attackPosPowerZeus.position, rangePowerZeus);
        }
    }
}