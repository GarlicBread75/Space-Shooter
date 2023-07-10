using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    Rigidbody2D rb;
    WaveSpawner waves;

    private void Start()
    {
        waves = FindObjectOfType<WaveSpawner>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -Random.Range(minSpeed, maxSpeed));
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || !collision.gameObject.CompareTag("Boss"))
        {
            waves.bulletsCount--;
        }
    }
}
