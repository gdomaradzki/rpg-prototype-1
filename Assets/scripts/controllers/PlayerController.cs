using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator animation;
    public Vector2 lastMove;
    private Rigidbody2D body;
    private Vector2 moveInput;
    private bool playerMoving;
    private bool attacking;
    public float attackSpeed;
    private float attackSpeedCount;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        lastMove = new Vector2(0, -1f);
    }
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput != Vector2.zero) {
            body.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            playerMoving = true;
            lastMove = moveInput;
        } else {
            body.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            attackSpeedCount = attackSpeed;
            attacking = true;
            animation.SetBool("Attacking", true);
        }
        if (attackSpeedCount > 0){
            attackSpeedCount -= Time.deltaTime;
        }
        if (attackSpeedCount <= 0) {
            attacking = false;
            animation.SetBool("Attacking", false);
        }
        animation.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animation.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animation.SetBool("PlayerMoving", playerMoving);
        animation.SetFloat("LastMoveX", lastMove.x);
        animation.SetFloat("LastMoveY", lastMove.y);
    }

}
