using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Lives")]
    public float lives;

    public TextMeshProUGUI gameOver;
    public GameObject gameOverScreen;
    public float textDelay;

    ScoreCounter score;
    public Respawn[] pls;
    Respawn currentShip;
    ShipStuff ship;
    UpgradeCounter upgrades;
    CheatsEnable cheating;
    OverheatMeter heat;
    AudioManager sound;

    private void Start()
    {
        score = GameObject.Find("SCO").GetComponent<ScoreCounter>();
        ship = GameObject.Find("Ship Manager").GetComponent<ShipStuff>();
        currentShip = ship.ships[ship.activeShip];
        upgrades = GameObject.Find("UCO").GetComponent<UpgradeCounter>();
        cheating = FindObjectOfType<CheatsEnable>();
        heat = FindObjectOfType<OverheatMeter>();
        sound = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (cheating.canCheat)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                lives++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss")) && lives > 0)
        {
            currentShip.Respawning();
        }
        else
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss")) && lives <= 0)
        {
            ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!currentShip.respawning)
        {
            if (collision.gameObject.CompareTag("EnemyBullet") && lives > 0)
            {
                currentShip.Respawning();
                Destroy(collision.gameObject);
            }
            else
            if (collision.gameObject.CompareTag("EnemyBullet") && lives <= 0)
            {
                ShowGameOverScreen();
            }
        }

        if (collision.gameObject.CompareTag("Gift"))
        {
            sound.Play("Gift");
            score.AddScore(500);
            heat.slider.value = 0;

            switch (collision.gameObject.GetComponent<Present>().weaponName)
            {
                case "Ion":
                    if (currentShip.activeGun == 0)
                    {
                        upgrades.AddUpgrade(1);
                    }
                    else
                    {
                        currentShip.SwitchGun(0);
                    }
                    break;

                case "Neutron":
                    if (currentShip.activeGun == 1)
                    {
                        upgrades.AddUpgrade(1);
                    }
                    else
                    {
                        currentShip.SwitchGun(1);
                    }
                    break;

                case "Laser":
                    if (currentShip.activeGun == 2)
                    {
                        upgrades.AddUpgrade(1);
                    }
                    else
                    {
                        currentShip.SwitchGun(2);
                    }
                    break;

                case "Vulcan":
                    if (currentShip.activeGun == 3)
                    {
                        upgrades.AddUpgrade(1);
                    }
                    else
                    {
                        currentShip.SwitchGun(3);
                    }
                    break;

                case "Plasma":
                    if (currentShip.activeGun == 4)
                    {
                        upgrades.AddUpgrade(1);
                    }
                    else
                    {
                        currentShip.SwitchGun(4);
                    }
                    break;

                case "Fork":
                    if (currentShip.activeGun == 5)
                    {
                        upgrades.AddUpgrade(1);
                    }
                    else
                    {
                        currentShip.SwitchGun(5);
                    }
                    break;

                default:
                    Debug.Log("presents broken soz");
                    break;
            }

            Destroy(collision.gameObject);
        }
        else
        if (collision.gameObject.CompareTag("Upgrade"))
        {
            sound.Play("Upgrade");
            heat.slider.value = 0;
            upgrades.AddUpgrade(1);
            score.AddScore(500);
            Destroy(collision.gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!currentShip.respawning)
        {
            if (lives > 0)
            {
                currentShip.Respawning();
            }
            else
            if (lives <= 0)
            {
                ShowGameOverScreen();
            }
        }
    }

    void ShowGameOverScreen()
    {
        AudioListener.volume = 0.25f;
        sound.Play("GameOver");
        gameObject.SetActive(false);
        GameOverScreen1();
        Invoke(nameof(GameOverScreen2), textDelay);
    }

    private void GameOverScreen1()
    {
        gameOver.gameObject.SetActive(true);
    }

    private void GameOverScreen2()
    {
        gameOverScreen.SetActive(true);
    }
}
