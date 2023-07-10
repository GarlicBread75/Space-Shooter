using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Swarms Controller")]
    public int enemiesLeft;
    public int bulletsCount;

    [Header("")]
    public int currentWave = 1;

    [Header("")]
    public Transform[] waveSpawnPoints;

    [Header("")]
    public GameObject[] enemyWaves;
    public GameObject[] bossWaves;

    [Header("")]
    public Transform[] moveSpots;
    public Transform[] originalMoveSpots;
    public Transform[] bossMoveSpots;

    [Header("")]
    public TextMeshProUGUI waveNum;
    public GameObject waveCount;
    public TextMeshProUGUI bossWave;
    public TextMeshProUGUI nice;
    public float delay;
    public float countdown;
    float constCountdown;

    ScoreCounter score;
    GameObject destroySwarmObject;
    public int dropLimit;

    public GameObject bossHpBar;
    public GameObject introText;

    int rNum;

    private void Start()
    {
        constCountdown = countdown;
        countdown = 0;
        ShowWaveText();
        Invoke(nameof(TextGone), delay - 3);
        Invoke(nameof(IntroGone), 6.1f);
        score = FindObjectOfType<ScoreCounter>();
    }

    private void FixedUpdate()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        if (enemiesLeft <= 0 && countdown <= 0)
        {
            countdown = constCountdown;
            StartingNewWave();
        }
    }

    void NextWave()
    {
        rNum = Random.Range(0, enemyWaves.Length);

        if (currentWave % 10 != 0)
        {
            if (rNum == enemyWaves.Length - 1)
            {
                if (Random.value > 0)
                {
                    destroySwarmObject = Instantiate(enemyWaves[rNum], new Vector2 (enemyWaves[rNum].transform.position.x, enemyWaves[rNum].transform.position.y), enemyWaves[rNum].transform.rotation);
                }
                else
                {
                    destroySwarmObject = Instantiate(enemyWaves[rNum], new Vector2 (-enemyWaves[rNum].transform.position.x, enemyWaves[rNum].transform.position.y), Quaternion.Euler(enemyWaves[rNum].transform.rotation.x, -enemyWaves[rNum].transform.rotation.y, enemyWaves[rNum].transform.rotation.z));
                }
            }
            else
            {
                destroySwarmObject = Instantiate(enemyWaves[rNum], waveSpawnPoints[Random.Range(0, waveSpawnPoints.Length)].position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(bossWaves[Random.Range(0, bossWaves.Length)], waveSpawnPoints[Random.Range(0, waveSpawnPoints.Length)].position, Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 180));
            bossHpBar.SetActive(true);
        }
    }

    void ShowWaveText()
    {
        waveNum.text = "Wave: " + currentWave.ToString();
        waveCount.SetActive(true);
        
        if (currentWave % 10 == 0 && currentWave != 0)
        {
            bossWave.gameObject.SetActive(true);
        }
        else
        if (currentWave == 69)
        {
            nice.gameObject.SetActive(true);
        }
    }

    void TextGone()
    {
        waveCount.SetActive(false);
        bossWave.gameObject.SetActive(false);
        nice.gameObject.SetActive(false);
    }

    void StartingNewWave()
    {
        bossHpBar.SetActive(false);
        Destroy(destroySwarmObject);
        currentWave++;
        if (currentWave > 1)
        {
            score.AddScore(10000);
        }
        ShowWaveText();
        Invoke(nameof(TextGone), 3);
        moveSpots[0].position = originalMoveSpots[0].position;
        moveSpots[1].position = originalMoveSpots[1].position;
        Invoke(nameof(NextWave), delay);
        dropLimit = 0;
    }

    void IntroGone()
    {
        introText.SetActive(false);
    }
}
