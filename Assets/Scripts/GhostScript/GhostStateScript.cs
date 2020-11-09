﻿using System;
using System.Net.Mail;
 using UnityEditor;
 using UnityEngine;

namespace GhostScript
{
    public class GhostStateScript : MonoBehaviour
    {
        internal bool _goingUp = false;
        internal bool _hitWall = false;
        internal Vector2 _startingPosition;
        private float _maxPosition;
        private float _minPosition;
        internal float life;

        public static event Action<string> GhostDeath;

        private void Start()
        {
            _startingPosition = transform.position;
            _maxPosition = transform.position.y + 5;
            _minPosition = transform.position.y - 5;
            life = 15;

        }

        private void FixedUpdate()
        {
            if (_hitWall)
            {
                _goingUp = !_goingUp;
                _hitWall = false;
            }
            else if (transform.position.y > _maxPosition || transform.position.y < _minPosition)
            {
                _goingUp = !_goingUp;
            }


    }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                _hitWall = true;
            }
        }

        public bool TakeDamage(float damage)
        {
            life -= damage;
            Debug.Log("ghost took damage");
            if (life <= 0)
            {
                Debug.Log("Ghost Dead");
                GhostDeath?.Invoke("GHOST");
                Destroy(gameObject);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
    }
}