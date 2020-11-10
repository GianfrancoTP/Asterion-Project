using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DefaultNamespace;

namespace PlayerScripts
{
    public class PlayerCollisionScript : MonoBehaviour
    {
        [SerializeField] private PlayerMainScript mainScript;
        
        void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (collisionInfo.collider.tag == "Ghost")
            {
                Debug.Log("Ghost");
                AudioControllerScript.PlayerDamageSound();
                GhostAttack();
                Debug.Log("Ghost Damage");
               
            }
            else if (collisionInfo.collider.tag == "Minotaur")
            {
                Debug.Log("Minotaur");
                MinetaurAttack();
                var magnitude = 10000;
 
                var force = transform.position - collisionInfo.transform.position;
 
                force.Normalize ();
                GetComponent<Rigidbody2D> ().AddForce (force * magnitude);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Rune")
            {
                AudioControllerScript.TakeObjectSound();
                Debug.Log("Found Rune");
                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == "Key")
            {
                AudioControllerScript.TakeObjectSound();
                getKey();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == "Door")
            {
                AudioControllerScript.EnterDoorSound();
                openDoor();
            }
            else if (other.gameObject.tag == "Ghost")
            {
                AudioControllerScript.PlayerDamageSound();
                GhostAttack();
               
                Debug.Log("Ghost Damage E");
                var magnitude = 10000;
 
                var force = transform.position - other.transform.position;
 
                force.Normalize ();
                GetComponent<Rigidbody2D> ().AddForce (force * magnitude);
            }
        }

        void FoundRune()
        {
            GameObject newText = new GameObject("You found a Rune", typeof(RectTransform));
            var newTextComp = newText.AddComponent<Text>();
            //newText.AddComponent<CanvasRenderer>();

            //Text newText = transform.gameObject.AddComponent<Text>();
            newTextComp.text = "You found a Rune";
            newTextComp.alignment = TextAnchor.MiddleCenter;
            newTextComp.fontSize = 10;

            newText.transform.SetParent(transform);
        }

        float Attack(GameObject Ghost)
        {
            return (float) 5.0;
        }

        void MinetaurAttack()
        {
            if (mainScript.healthScript.ReceiveDamage(20))
            {
                Debug.Log("PlayerDied");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            }
        }

        void GhostAttack()
        {
            if (mainScript.healthScript.ReceiveDamage(20))
            {
                Debug.Log("PlayerDied");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            }
        }

        void getKey()
        {
            mainScript.stateScript.hasKey = true;
            Debug.Log("Found Key");
        }

        void openDoor()
        {
            if (mainScript.stateScript.hasKey)
            {
                Debug.Log("Door opened");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else
            {
                Debug.Log("Missing Key");
            }
        }
    }
}