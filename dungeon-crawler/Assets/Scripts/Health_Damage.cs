using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health_Damage : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;
    private bool isAlive = true;
    private bool isGameOver = false;
    private Vector3 respawnPoint;
    private UIManager uiManager;
    internal int teamId;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            InflictDamage();
        }
        Debug.Log("Health: " + health);
        Debug.Log("Lives: " + lives);
    }

    private void InflictDamage()
    {
        health--;
        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();
        if (health == 0)
        {
            isAlive = false;
            lives--;
            if (lives != 0)
            {
                uiManager.SetYouHaveDiedText(true);
            }
            //gameObject.SetActive(false);
        }
        if (lives == 0)
        {
            isGameOver = true;
            uiManager.SetGameOverText(true);
        }
    }

    public void Respawn()
    {
        if (!isAlive && !isGameOver)
        {
            isAlive = true;
            health = 3;
            uiManager.SetYouHaveDiedText(false);
            uiManager.SetHealth(health);
            uiManager.SetHealthCount();
            gameObject.SetActive(true);
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
