﻿using DefaultNamespace;
using System;
using System.Net.Mail;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine;

namespace MinotaurScripts
{
    public class MinotaurState : MonoBehaviour
    {
        
        internal float life;
        internal bool stuned = false;

        public static event Action MinotaurStun;

        private void Start()
        {
            life = 15;
        }

        public void TakeDamage(float damage)
        {
            life -= damage;
            Debug.Log("Minotaur took damage");
            AudioControllerScript.MinotaurDamaged();
            if (life <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                AudioControllerScript.MinautorStunSound();
                Debug.Log("MinotaurStuned");
                MinotaurStun?.Invoke();
                stuned = true;
                Invoke("WakeUp", 5.0f);  
            }
        }

        void WakeUp()
        {
            GetComponent<Collider2D>().enabled = true;
            stuned = false;
        }
        
        
        
        
        

    }
}