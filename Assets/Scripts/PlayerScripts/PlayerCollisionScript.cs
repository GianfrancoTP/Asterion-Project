using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerCollisionScript : MonoBehaviour
    {
        [SerializeField] private PlayerMainScript mainScript;

        private void Start()
        {
           Debug.Log("WGERTBVERHBRNBTRNer");
        }

        void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (collisionInfo.collider.tag == "Ghost")
            {
                Debug.Log("Ghost");
            }
            
            else if (collisionInfo.collider.tag == "door")
            {
                //FindObjectOfType<GameManager>().WinGame();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Rune")
            {
                Debug.Log("Found Rune");
                Destroy(other.gameObject);
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
    }
}