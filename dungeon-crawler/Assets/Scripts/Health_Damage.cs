using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Health_Damage : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;
    private bool isAlive = true;
    private Vector3 respawnPoint;
    public GameObject gameOver;
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
            gameObject.SetActive(false);
        }
        if (lives == 0)
        {
            gameOver.SetActive(true);
        }
    }

    public void Respawn()
    {
        if (!isAlive)
        {
            gameObject.SetActive(true);
            transform.position = respawnPoint;
        }
    }

    internal void TakeDamage(int damageAmount)
    {
        throw new NotImplementedException();
    }
}
