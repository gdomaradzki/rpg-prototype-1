using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {
    // Movement
    public float moveSpeed;
    public float timeBetweenMovement;
    public float movementTime;
    private Vector3 movementDirection;

    // Counters
    private float timeBetweenMovementCounter;
    private float movementTimeCounter;

    // Physics
    private Rigidbody2D body;

    // Animator
    private Animator animator;

    // State
    private bool moving;

    // Helpers
    private const float direction = 1f;

	// Use this for initialization
	void Start () {
        // Set Components
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Set Counters
        timeBetweenMovementCounter = Random.Range(timeBetweenMovement * 0.75f, timeBetweenMovement * 1.25f);
        movementTimeCounter = Random.Range(movementTime * 0.75f, movementTime * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
            // Counts down to zero
            movementTimeCounter -= Time.deltaTime;

            // Sets the velocity to the right direction
            body.velocity = movementDirection;

            // When the counter gets to zero
            if (movementTimeCounter < 0f) {
                // Set the movement to false
                moving = false;
                // Reset counter to a random number
                timeBetweenMovementCounter = Random.Range(timeBetweenMovement * 0.75f, timeBetweenMovement * 1.25f);
            }
        } else {
            // Counts down to zero
            timeBetweenMovementCounter -= Time.deltaTime;

            // Set the velocity to zero
            body.velocity = Vector2.zero;

            // When the counter gets to zero
            if (timeBetweenMovementCounter < 0f) {
                // Sets movement to true
                moving = true;
                // Generates a timer and direction for the next tick movement
                movementTimeCounter = Random.Range(movementTime * 0.75f, timeBetweenMovement * 1.25f);
                movementDirection = new Vector3(Random.Range(-direction, direction) * moveSpeed,
                                                Random.Range(-direction, direction) * moveSpeed, 0f);
            }
        }
        animator.SetBool("Moving", moving);
	}
}
