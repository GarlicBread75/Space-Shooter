using UnityEngine;

public class Asteroids : MonoBehaviour
{
    WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        waveSpawner.enemiesLeft++;
        gameObject.GetComponent<ParticleSystem>().Play();
        Invoke(nameof(Gone), 30f);
    }

    void Gone()
    {
        waveSpawner.enemiesLeft--;
        Destroy(gameObject);
    }
}
