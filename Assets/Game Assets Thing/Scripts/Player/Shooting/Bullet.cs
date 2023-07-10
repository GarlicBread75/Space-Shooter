using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float damage;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
