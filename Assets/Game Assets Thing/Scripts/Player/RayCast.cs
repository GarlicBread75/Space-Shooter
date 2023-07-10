using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject ray;
    public RaycastHit2D hit;
    public bool enemyContact;

    private void Update()
    {
        hit = Physics2D.Raycast(ray.transform.position, Vector2.up);
        Debug.DrawRay(ray.transform.position, Vector2.up * hit.distance, Color.red);

        if (hit.collider.gameObject.CompareTag("Enemy") || hit.collider.gameObject.CompareTag("Boss"))
        {
            Debug.DrawRay(ray.transform.position, Vector2.up * hit.distance, Color.green);
            enemyContact = true;
        }
        else
        if (hit.collider.gameObject.CompareTag("Gift") || hit.collider.gameObject.CompareTag("Upgrade") || hit.collider.gameObject.CompareTag("EnemyBullet") || hit.collider.gameObject.CompareTag("Food") || hit.collider.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.DrawRay(ray.transform.position, Vector2.up * hit.distance, Color.white);
            enemyContact = false;
        }
        else
        {
            Debug.DrawRay(ray.transform.position, Vector2.up * hit.distance, Color.red);
            enemyContact = false;
        }
    }
}
