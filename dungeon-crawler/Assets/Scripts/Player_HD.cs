using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_HD : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;
    [HideInInspector] public bool isAlive = true;
    private bool isGameOver = false;
    private Vector3 respawnPoint;
    //public GameObject gameOver;
    private UIManager uiManager;
    private SpriteRenderer spriteRenderer;
    private YareliPlayerController yareliPlayerController;
    private JumpScript jump;
    internal int teamId;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        yareliPlayerController = GetComponent<YareliPlayerController>();
        jump = GetComponent<JumpScript>();
        uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();
        respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            InflictDamage();
        }
        if (lives == 0)
        {
            isGameOver = true;
            uiManager.SetGameOverText(true);
            uiManager.SetYouHaveDiedText(false);
        }
        Debug.Log("Health: " + health);
        Debug.Log("Lives: " + lives);
    }

    private void InflictDamage()
    {
        health--;
        if (health == 0)
        {
            isAlive = false;
            lives--;
            spriteRenderer.enabled = false;
            yareliPlayerController.enabled = false;
            jump.enabled = false;
            uiManager.SetYouHaveDiedText(true);
        }
        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();
        if (lives == 0)
        {
            isGameOver = true;
        }
    }

    public void Respawn()
    {
        if (!isAlive && !isGameOver)
        {
            spriteRenderer.enabled = true;
            yareliPlayerController.enabled = true;
            jump.enabled = true;
            isAlive = true;
            health = 3;
            uiManager.SetYouHaveDiedText(false);
            uiManager.SetHealth(health);
            uiManager.SetHealthCount();
            transform.position = respawnPoint;
        }
        if (lives != 0)
        {
            isGameOver = false;
        }
    }

    internal void TakeDamage(int damageAmount)
    {
        throw new NotImplementedException();
    }
}