using DefaultNamespace;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerScripts
{
    public class PlayerInputScript : MonoBehaviour
    {
        internal Vector3 change;
        internal bool basicAttack;
        internal bool powerAttack;
        internal bool utilityAttack;
        private Animator animator;
        public GameObject player;

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
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Quit!");
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Cheat collider enabled");
                player.GetComponent<BoxCollider2D>().enabled = !player.GetComponent<BoxCollider2D>().enabled;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                float actual_speed = player.GetComponent<PlayerMovementScript>().movementSpeed;
                if (actual_speed != 15)
                {
                    Debug.Log("speed set to 15");
                    player.GetComponent<PlayerMovementScript>().movementSpeed = 15;
                }
                else
                {
                    Debug.Log("speed set to 5");
                    player.GetComponent<PlayerMovementScript>().movementSpeed = 5;
                }
            }
        }
    }
}