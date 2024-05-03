using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health_Damage : MonoBehaviour
{
    public int health = 3;
    private UIManager uiManager;
    private void Start()
    {
        uiManager = GetComponent<UIManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            InflictDamage();
        }
        Debug.Log(health);
    }

    private void InflictDamage()
    {
        health--;
        uiManager.SetHealth(health);
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
