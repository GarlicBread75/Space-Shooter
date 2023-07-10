using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHp;
    public float currentHp;

    [Header("Loot Drop")]
    public GameObject[] Pickups;

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

        maxHp = waveSpawner.currentWave / 4;

        if (maxHp < 1)
        {
            maxHp = 1;
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
            Die();
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
        Destroy(destroyPls, 0.6f);
        waveSpawner.enemiesLeft--;
        killScript.AddKill(1);
        scoreScript.AddScore(1000 + (waveSpawner.currentWave * 100));
        ChoosingRandomLoot(Random.Range(1, 1001));
        Destroy(gameObject);
    }

    void ChoosingRandomLoot(int rnd)
    {
        for (int i = 0; i < Pickups.Length; i++)
        {
            if (rnd <= Pickups[i].GetComponent<DropChance>().dropChance)
            {
                if (!Pickups[i].CompareTag("Food"))
                {
                    if (waveSpawner.dropLimit < 2)
                    {
                        Instantiate(Pickups[i], transform.position, Quaternion.identity);
                        waveSpawner.dropLimit++;
                        break;
                    }
                }
                else
                {
                    SpawnFood(Random.Range(1, 11), i);
                    break;
                }
            }
        }
    }

    void SpawnFood(int foodNum, int foodPos)
    {
        if (foodNum >= 4 && foodNum <= 10)
        {
            Instantiate(Pickups[foodPos], transform.position, Quaternion.identity);
        }
        else
        if (foodNum == 3)
        {
            Instantiate(Pickups[foodPos], transform.position, Quaternion.identity);
            Instantiate(Pickups[foodPos], transform.position, Quaternion.identity);
        }
        else
        if (foodNum == 1 || foodNum == 2)
        {

        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }
}
