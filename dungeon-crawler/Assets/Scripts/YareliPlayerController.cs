using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class YareliPlayerController : MonoBehaviour
{
    public float walkSpeed = 6f;
    Vector2 moveInput;

    [SerializeField]
    private bool _isMoving = false;
    private bool canShoot = true;
    public float fireRate = 1f;


    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if (_isFacingRight != value)
            {
                //Flip the local scale to make the player face the opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }

            _isFacingRight = value;
        }
    }

    Rigidbody2D rb;
    Animator animator;
    public GameObject projectilePrefab;
    public Transform firePoint;
    private Player_HD playerHD;
    private WinScreen winScreen;

    private void Start()
    {
        playerHD = GetComponent<Player_HD>();
        winScreen = FindObjectOfType<WinScreen>().GetComponent<WinScreen>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x < 0 && !IsFacingRight)
        {
            // Face the right
            IsFacingRight = true;
        }
        else if (moveInput.x > 0 && IsFacingRight)
        {
            // Face the left
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnFireInput(InputAction.CallbackContext context)
    {
        if (context.performed && canShoot)
        {
            canShoot = false;
            StartCoroutine("FireRate");
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Debug.Log("Shots fired");
        }
    }

    public void OnRestartInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerHD.Respawn();
            Debug.Log("Respawn");
        }
    }

    public void OnQuitInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void OnWinInput(InputAction.CallbackContext context)
    {
        if (context.performed && winScreen.win)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            } else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
