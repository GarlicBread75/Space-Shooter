using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject[] bullets;
    float timer;
    float min;
    float max;

    WaveSpawner waves;
    AudioManager sound;

    private void Start()
    {
        sound = FindObjectOfType<AudioManager>();
        min = Random.Range(5f, 35f);
        max = Random.Range(45f, 80f);
        waves = FindObjectOfType<WaveSpawner>();
        timer = Random.Range(min, max);
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
            Instantiate(bullets[Random.Range(0, bullets.Length)], transform.position, Quaternion.identity);
            waves.bulletsCount++;
        }
    }
}
