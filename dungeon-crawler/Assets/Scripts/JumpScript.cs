using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class JumpScript : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;

    public Rigidbody2D rb;
    bool isJumping = false;
    bool isGrounded = true;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping && isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
            isGrounded = false;
            Debug.Log("Jump");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isJumping = false;
            isGrounded = true;
            Debug.Log("Player is grounded");
        }
    }
}
