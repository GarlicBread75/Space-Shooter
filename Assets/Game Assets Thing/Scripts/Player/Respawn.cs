using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("Respawn")]
    public Transform RespawnPoint;
    public Transform RespawnMove;
    public float moveDelay;
    public Rigidbody2D playerRb;
    public float iframesDelay;
    public GameObject shield;
    public GameObject deathEffect;

    Gun gun;
    PlayerCollision life;
    ShipStuff ship;
    CheatsEnable cheating;
    AudioManager sound;
    UpgradeCounter upgrades;
    [HideInInspector] public bool respawning;

    int tabNum;

    private void Start()
    {
        ship = GameObject.Find("Ship Manager").GetComponent<ShipStuff>();
        gun = FindObjectOfType<Gun>();
        life = GetComponent<PlayerCollision>();
        cheating = FindObjectOfType<CheatsEnable>();
        sound = FindObjectOfType<AudioManager>();
        upgrades = GameObject.Find("UCO").GetComponent<UpgradeCounter>();
    }

    void MakingSureOfInvulnerability()
    {
        if (ship.shield)
        {
            InvulnerableVisual();
            Physics2D.IgnoreLayerCollision(6, 8, true);
            Physics2D.IgnoreLayerCollision(6, 9, true);
            Invoke(nameof(InvulnerableEnd), iframesDelay);
            ship.shield = false;
        }
    }

    public void Respawning()
    {
        Die();
        Invoke(nameof(Move), moveDelay);

        if (upgrades.upgrade <= 10)
        {
            upgrades.upgrade -= 1;
        }
        else
        if (upgrades.upgrade >= 11 && upgrades.upgrade <= 19)
        {
            upgrades.upgrade -= 2;
        }
        else
        if (upgrades.upgrade >= 20)
        {
            upgrades.upgrade -= 5;
        }
    }

    public void Die()
    {
        respawning = true;
        upgrades.changeAfterRespawn = true;
        GameObject plsDestroy = Instantiate(deathEffect, transform.position, Quaternion.identity);
        sound.Play("PlayerDie");
        guns[activeGun].gameObject.SetActive(false);
        life.lives--;
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);
        transform.position = RespawnPoint.position;
        playerRb.constraints = RigidbodyConstraints2D.FreezePosition;
        gun.canShoot = false;
        Destroy(plsDestroy, 0.5f);
        for (int i = 0; i < gun.lr.Length; i++)
        {
            gun.lr[i].laser = false;
            gun.lr[i].plasma = false;
        }
    } 

    public void Move()
    {
        sound.Play("Respawn");
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);
        InvulnerableVisual();
        guns[activeGun].gameObject.SetActive(true);
        playerRb.constraints = RigidbodyConstraints2D.None;
        gun.canShoot = true;
        Invoke(nameof(InvulnerableEnd), iframesDelay);
        transform.SetPositionAndRotation(RespawnMove.transform.position, RespawnMove.transform.rotation);
        upgrades.canChange = true;
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        ship.below6 = true;
    }

    void InvulnerableVisual()
    {
        ship.shield = true;
        shield.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
    }

    void InvulnerableEnd()
    {
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(6, 9, false);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        shield.SetActive(false);
        respawning = false;
    }

    public int activeGun;
    public bool gunSwitch;

    [Header("Gun")]
    public Gun[] guns;

    private void Update()
    {
        if (gameObject.activeInHierarchy && ship.shield)
        {
            MakingSureOfInvulnerability();
        }

        if (cheating.canCheat)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                gunSwitch = !gunSwitch;
                ship.shipSwitch = false;
            }

            if (gunSwitch)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SwitchGun(0);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    SwitchGun(1);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    SwitchGun(2);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    SwitchGun(3);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    SwitchGun(4);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    SwitchGun(5);
                }
                else
                if (Input.GetKeyDown(KeyCode.Tab) || Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    tabNum++;

                    if (tabNum < 0)
                    {
                        tabNum = 5;
                    }
                    else
                    if (tabNum > 5)
                    {
                        tabNum = 0;
                    }

                    SwitchGun(tabNum);

                }
                else
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    tabNum--;

                    if (tabNum < 0)
                    {
                        tabNum = 5;
                    }
                    else
                    if (tabNum > 5)
                    {
                        tabNum = 0;
                    }

                    SwitchGun(tabNum);
                }
            }
        }
    }

    public void SwitchGun(int gunNum)
    {
        guns[activeGun].gameObject.SetActive(false);
        activeGun = gunNum;
        guns[activeGun].gameObject.SetActive(true);
        guns[activeGun].heatBuildUp = guns[activeGun].heatIncrease;
    }
}
