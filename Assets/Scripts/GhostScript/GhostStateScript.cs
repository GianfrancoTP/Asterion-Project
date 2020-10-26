﻿using System;
using System.Net.Mail;
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

        private void Start()
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
    }
}