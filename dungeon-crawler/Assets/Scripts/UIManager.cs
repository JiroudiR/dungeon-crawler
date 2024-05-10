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

    public void SetHealth(int health)
    {
        healthBar.value = health;
        if (health == 0)
        {
            fillArea.SetActive(false);
        }
    }

    public void SetHealthCount()
    {
        int healthText = FindObjectOfType<Health_Damage>().health;
        healthCount.text = healthText.ToString() + " HP";
    }

    public void SetLivesCount()
    {
        int livesText = FindObjectOfType<Health_Damage>().lives;
        livesCount.text = "Lives: " + livesText.ToString();
    }

    public void SetYouHaveDiedText(bool input)
    {
        youHaveDiedText.SetActive(input);
    }

    public void SetGameOverText(bool input)
    {
        gameOverText.SetActive(input);
    }
}
