using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class JumpScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D player;
    public float jumpSpeed = 8f;
    private Vector2 jumpInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }
}
