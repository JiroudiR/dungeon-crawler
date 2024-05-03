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

    public void SetHealth(int health)
    {
        healthBar.value = health;
        if (health == 0)
        {
            Destroy(fillArea);
        }
    }

    public void SetHealthCount()
    {
        
    }
}
