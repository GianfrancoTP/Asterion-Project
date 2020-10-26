using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovementScript : MonoBehaviour
    {
        [SerializeField] private PlayerMainScript mainScript;
        public float movementSpeed = 5;
        private Vector3 change;
        private void FixedUpdate()
        {
            change = mainScript.inputScript.change;
            change.x *= movementSpeed * Time.deltaTime;
            change.y *= movementSpeed * Time.deltaTime;
            transform.Translate(new Vector3(change.x, change.y));
        }
    }
}