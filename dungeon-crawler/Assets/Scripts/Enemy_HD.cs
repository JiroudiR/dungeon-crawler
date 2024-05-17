using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HD : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health--;
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
