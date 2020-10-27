using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace PlayerScripts
{
    public class PlayerHealthScript : MonoBehaviour
    {
        [SerializeField] private PlayerMainScript mainScript;
        internal float life;

        private void Start()
        {
            life = 100;
        }

        public bool ReceiveDamage(float damage)
        {
            life -= damage;
            if (life <= 0)
            {
                return true;
            }

            return false;
        }
    }
}