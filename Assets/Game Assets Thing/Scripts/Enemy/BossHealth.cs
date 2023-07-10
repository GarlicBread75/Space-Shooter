using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHp;
    public float currentHp;

    [Header("Loot Drop")]
    public GameObject[] Pickups;
    public int[] dropChances;
    public GameObject food;

    [Header("Death Effect")]
    public GameObject deathEffect;

    //Misc
    KillCounter killScript;
    ScoreCounter scoreScript;
    WaveSpawner waveSpawner;
    AudioManager sound;

    private void Start()
    {
        killScript = GameObject.Find("KCO").GetComponent<KillCounter>();
        scoreScript = GameObject.Find("SCO").GetComponent<ScoreCounter>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
        sound = FindObjectOfType<AudioManager>();
        waveSpawner.enemiesLeft++;

        maxHp = waveSpawner.currentWave * 10;

        if (maxHp < 1)
        {
            maxHp = 1;
        }

        int e = Random.Range(1, 4);
        switch (e)
        {
            case 1:
                break;

            case 2:
                maxHp /= 2;
                break;

            case 3:
                maxHp *= 2;
                break;
        }

        currentHp = maxHp;
    }

    private void FixedUpdate()
    {
        if (currentHp <= 0)
        {
            Die();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(maxHp / 20);
        }
    }

    public void Die()
    {
        int e = Random.Range(1, 6);

        switch (e)
        {
            case 1:
                sound.Play("EnemyDie1");
                break;

            case 2:
                sound.Play("EnemyDie2");
                break;

            case 3:
                sound.Play("EnemyDie3");
                break;

            case 4:
                sound.Play("EnemyDie4");
                break;

            case 5:
                sound.Play("EnemyDie5");
                break;
        }

        GameObject destroyPls = Instantiate(deathEffect, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 361)));
        Destroy(destroyPls, 2f);
        waveSpawner.enemiesLeft--;
        killScript.AddKill(1);
        scoreScript.AddScore(10000 * (waveSpawner.currentWave / 10) + (10000 * (waveSpawner.currentWave / 10))/10);
        ChoosingRandomLoot(Random.Range(1, dropChances[dropChances.Length - 1]));
        Destroy(gameObject);
    }

    void ChoosingRandomLoot(int rnd)
    {
        for (int i = 0; i < Pickups.Length; i++)
        {
            if (rnd <= dropChances[i])
            {
                Instantiate(Pickups[i], transform.position, Quaternion.identity);
                break;
            }
        }

        SpawnManyFoods();
    }

    void SpawnManyFoods()
    {
        for (int i = 0; i < Random.Range(10, 31); i++)
        {
            Instantiate(food, transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }
}
