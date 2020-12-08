﻿using UnityEngine;

namespace GhostScript
{
    public class GhostAgroScript : MonoBehaviour
    {
        [SerializeField] Transform player;

        [SerializeField] float aggroRange;

        [SerializeField] float moveSpeed;

        Rigidbody2D rb2d;
        
        [SerializeField] private GhostMainScript mainScript;
        public float distanceToPlayer;
        public bool isGhostClose;


        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            //distance to player
            distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < aggroRange)
            {
                //code to chase player
                isGhostClose = true;
                this.gameObject.GetComponent<GhostStateScript>().Recalibrate();
            }
            else
            {
                
                isGhostClose = false;
                //stop chasing player
            }
            

        }

        public void chasePlayer()
        {
            if (transform.position.x < player.position.x && transform.position.y < player.position.y)
            {
                //minotauro a la izquierda del jugador y abajo
                rb2d.velocity = new Vector2(moveSpeed, moveSpeed);
            }

            else if (transform.position.x < player.position.x && transform.position.y > player.position.y)
            {
                //minotauro a la izquierda y arriba de el
                rb2d.velocity = new Vector2(moveSpeed, -moveSpeed);
            }

            else if (transform.position.x > player.position.x && transform.position.y < player.position.y)
            {
                //minotaur a la derecha y abajo del jugador
                rb2d.velocity = new Vector2(-moveSpeed, moveSpeed);
            }
            else if (transform.position.x > player.position.x && transform.position.y > player.position.y)
            {
                //minotauro a la derecha del jugador y arriba de el
                rb2d.velocity = new Vector2(-moveSpeed, -moveSpeed);
            }
        }

        public void stopChasingPlayer()
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}