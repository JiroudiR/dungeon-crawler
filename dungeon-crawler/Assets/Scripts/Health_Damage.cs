using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health_Damage : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;
    [HideInInspector] public bool isAlive = true;
    private bool isGameOver = false;
    private Vector3 respawnPoint;
    //public GameObject gameOver;
    private UIManager uiManager;
    internal int teamId;

    private void Start()
    {
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
<<<<<<< HEAD

        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();
        if (health <= 0)

        if (health == 0)

        {
            isAlive = false;
            lives--;
            //gameObject.SetActive(false);
            uiManager.SetGameOverText();
        }

=======
        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();
>>>>>>> 00f15b74d29d622d1c7fbc4e781e2d260b3f2056
        if (lives == 0)
        {
            isGameOver = true;
        }
<<<<<<< HEAD

        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();

=======
        if (health == 0)
        {
            isAlive = false;
            lives--;
            //gameObject.SetActive(false);
            uiManager.SetYouHaveDiedText(true);
        }
        uiManager.SetHealth(health);
        uiManager.SetHealthCount();
        uiManager.SetLivesCount();
>>>>>>> 00f15b74d29d622d1c7fbc4e781e2d260b3f2056
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
