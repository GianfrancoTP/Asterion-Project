using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    PlayerUpdate update;
    PlayerMove movement;
    PlayerInput input;
    PlayerCollision collision;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        update = GetComponent<PlayerUpdate>();
        movement = GetComponent<PlayerMove>();
        input = GetComponent<PlayerInput>();
        collision = GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        change = input.MovementInput(change);
        movement.MoveCharacter(change, speed);
        update.AnimationAndMove(animator, change);
    }
}