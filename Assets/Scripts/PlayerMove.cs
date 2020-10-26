using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public void MoveCharacter(Vector3 change, float speed)
    {
        change.x *= speed * Time.deltaTime;
        change.y *= speed * Time.deltaTime;
        transform.Translate(new Vector3(change.x, change.y));
    }
}
