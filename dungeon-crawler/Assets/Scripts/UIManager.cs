using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public GameObject fillArea;
    public TMP_Text healthCount;
    public TMP_Text livesCount;
    public GameObject gameOverText;
    public GameObject youHaveDiedText;
    public GameObject player;
    private Player_HD hDScript;

    private void Start()
    {
        hDScript = FindObjectOfType<YareliPlayerController>().GetComponent<Player_HD>();
    }

        
    

    public void SetHealth(int health)
    {
        healthBar.value = health;
        if (health == 0)
        {
            fillArea.SetActive(false);
        }
        if (player.GetComponent<Player_HD>().isAlive)
        {
            fillArea.SetActive(true);
        }
    }

    public void SetHealthCount()
    {
        int healthText = FindObjectOfType<Player_HD>().health;
        healthCount.text = healthText.ToString() + " HP";
    }

    public void SetLivesCount()
    {
        int livesText = FindObjectOfType<Player_HD>().lives;
        livesCount.text = "Lives: " + livesText.ToString();
    }

    public void SetYouHaveDiedText(bool input)
    {
        youHaveDiedText.SetActive(input);
    }

    public void SetGameOverText(bool input)
    {
        gameOverText.SetActive(input);
        //gameOverText = FindObjectOfType<Health_Damage>().gameOver;
    }
}
