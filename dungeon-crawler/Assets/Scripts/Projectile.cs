using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public GameObject projectilePrefab;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitToDestroy");
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(Vector3.forward * 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(projectilePrefab);
    }
}
