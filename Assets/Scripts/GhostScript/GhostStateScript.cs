using DefaultNamespace;
using System;
using System.Net.Mail;
 using UnityEditor;
 using UnityEngine;

namespace GhostScript
{
    public class GhostStateScript : MonoBehaviour
    {
        internal bool _goingUp = true;
        internal bool _hitWall = false;
        internal Vector2 _startingPosition;
        private float _maxPosition;
        private float _minPosition;
        internal float life;

        public static event Action<string> GhostDeath;
        public static event Action GhostDamage;

        private void Start()
        {
            _startingPosition = transform.position;
            _maxPosition = transform.position.y + 5;
            _minPosition = transform.position.y - 5;
            life = 15;

        }

        public void Recalibrate()
        {
            _startingPosition = transform.position;
            _maxPosition = transform.position.y + 5;
            _minPosition = transform.position.y - 5;
        }

        private void FixedUpdate()
        {
            if (_hitWall)
            {
                _goingUp = !_goingUp;
                _hitWall = false;
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
            GhostDamage?.Invoke();
            life -= damage;
            Debug.Log("ghost took damage");
            //AudioControllerScript.GhostDamaged();
            if (life <= 0)
            {
                //AudioControllerScript.GhostDeathSound();
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