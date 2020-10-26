using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    PlayerMove movement;
    void Start()
    {
        movement = GetComponent<PlayerMove>();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "enemy")
        {
            //FindObjectOfType<GameManager>().LoseGame();
        }
        else if (collisionInfo.collider.tag == "door")
        {
            //FindObjectOfType<GameManager>().WinGame();
        }
    }
}
