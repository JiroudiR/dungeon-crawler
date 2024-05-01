using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health_Damage : MonoBehaviour
{
    public int health = 3;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
        Debug.Log(health);
    }

    private void Damage()
    {
        health--;
        if (health == 0)
        {
            isDead = true;
            Destroy(this.gameObject);
        }
    }
}
