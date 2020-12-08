using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovementScript : MonoBehaviour
    {
        [SerializeField] private PlayerMainScript mainScript;
        public float movementSpeed = 5;
        private Vector3 change;
        public GameObject attackPos;
        public GameObject zeusPowerPos;

        private void FixedUpdate()
        {
            change = mainScript.inputScript.change;
            change.x *= movementSpeed * Time.deltaTime;
            change.y *= movementSpeed * Time.deltaTime;
            transform.Translate(new Vector3(change.x, change.y));
            if(change.x > 0)
            {
                Vector3 pos= new Vector3(1,0,0);
                attackPos.transform.position = this.gameObject.transform.position+ pos;
                zeusPowerPos.transform.position = this.gameObject.transform.position+ new Vector3((float) 2.5, 0, 0);
            }

            if (change.x < 0)
            {
                Vector3 pos= new Vector3(-1,0,0);
                attackPos.transform.position = this.gameObject.transform.position+ pos;
                zeusPowerPos.transform.position = this.gameObject.transform.position+ new Vector3((float) -2.5, 0, 0);
            }
            if(change.y > 0)
            {
                Vector3 pos= new Vector3(0,1,0);
                attackPos.transform.position = this.gameObject.transform.position+ pos;
                zeusPowerPos.transform.position = this.gameObject.transform.position+ new Vector3(0, (float) 2.5, 0);
            }

            if (change.y < 0)
            {
                Vector3 pos= new Vector3(0,-1,0);
                attackPos.transform.position = this.gameObject.transform.position + pos;
                zeusPowerPos.transform.position = this.gameObject.transform.position+ new Vector3(0, (float) -2.5, 0);
            }
        }
    }
}