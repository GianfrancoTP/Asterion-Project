using DefaultNamespace;
using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerInputScript : MonoBehaviour
    {
        internal Vector3 change;
        internal bool basicAttack;
        internal bool powerAttack;
        internal bool utilityAttack;
        private Animator animator;

        [SerializeField] private PlayerMainScript mainScript;
        public static event Action Attac;

        public void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            if (change != Vector3.zero)
            {
                Debug.Log("Entro");
                Debug.Log(change.x);
                Debug.Log(change.y);
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                basicAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                powerAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                utilityAttack = true;
            }
        }
    }
}