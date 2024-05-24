using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class JumpScript : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;

    public Rigidbody2D rb;
    bool isJumping = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            StartCoroutine("JumpDelay");
            isJumping = true;
            Debug.Log("Jump");
        }
    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(1.25f);
        isJumping = false;
    }
}
