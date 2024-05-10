using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 jumpInput;
    private Rigidbody2D rb;
    public float jumpSpeed = 8f; 
    private SpriteRenderer rbSprite;
    private float moveSpeed = 6f;
    public Animator animator;
    private Rigidbody2D player;
    private float direction = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = moveInput * moveSpeed;
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
    }



    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        rbSprite.flipX = moveInput.x > 0;
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValue<Vector2>();
        rbSprite.flipX = jumpInput.x > 0;
    }
    public void OnRestartInput()
    {
        gameObject.GetComponent<Health_Damage>().Respawn();
    }
}
