using Unity.VisualScripting;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject[] bullets;
    float timer;
    public float min;
    public float max;

    WaveSpawner waves;
    AudioManager sound;

    private void Start()
    {
        sound = FindObjectOfType<AudioManager>();
        waves = FindObjectOfType<WaveSpawner>();
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        if (waves.bulletsCount < 10)
        {
            timer = Random.Range(min, max);
            sound.Play("EnemyShoot");
            Instantiate(bullets[Random.Range(0, bullets.Length)], new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y), Quaternion.identity);
        }
    }
}
