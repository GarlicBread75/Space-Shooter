using TMPro;
using UnityEngine;

public class UpgradeCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    [HideInInspector] public int upgrade = 0;
    [HideInInspector] public bool canChange;
    [HideInInspector] public bool changeAfterRespawn;
    ShipStuff ship;
    CheatsEnable cheats;
    public Respawn[] pls;

    public GameObject upgradeArrow;
    Vector2 playerPos;
    float yPos;
    float xPos;

    private void Start()
    {
        ship = FindObjectOfType<ShipStuff>();
        cheats = FindObjectOfType<CheatsEnable>();
    }

    void FixedUpdate()
    {
        ShowUpgrades();

        if (upgradeArrow.activeInHierarchy)
        {
            yPos += Time.deltaTime * 1.5f;
            upgradeArrow.transform.position = new Vector2(xPos, yPos);
        }
    }

    private void Update()
    {
        if (upgrade < 0)
        {
            upgrade = 0;
        }
        else
        if (upgrade >= 0 && upgrade <= 9 && canChange && ship.activeShip != 0)
        {
            ship.SwitchShip(0);
            if (!changeAfterRespawn)
            {
                ShowArrow();
                changeAfterRespawn = false;
            }
            canChange = false;
            Invoke(nameof(ArrowGone), 0.5f);  
        }
        else
        if (upgrade >= 10 && upgrade <= 14 && canChange && ship.activeShip != 1)
        {
            ship.SwitchShip(1);
            if (!changeAfterRespawn)
            {
                ShowArrow();
                changeAfterRespawn = false;
            }
            canChange = false;
            Invoke(nameof(ArrowGone), 0.5f);
        }
        else
        if (upgrade >= 15 && upgrade <= 19 && canChange && ship.activeShip != 2)
        {
            ship.SwitchShip(2);
            if (!changeAfterRespawn)
            {
                ShowArrow();
                changeAfterRespawn = false;
            }
            canChange = false;
            Invoke(nameof(ArrowGone), 0.5f);
        }
        else
        if (upgrade >= 20 && canChange && ship.activeShip != 3)
        {
            ship.SwitchShip(3);
            if (!changeAfterRespawn)
            {
                ShowArrow();
                changeAfterRespawn = false;
            }
            canChange = false;
            Invoke(nameof(ArrowGone), 0.5f);
        }

        if (cheats.canCheat)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                canChange = true;
                upgrade++;
            }
            else
            if (Input.GetKeyDown(KeyCode.Y))
            {
                canChange = true;
                upgrade--;
            }
        }
    }

    public void ShowUpgrades()
    {
        counter.text = upgrade.ToString();
    }

    public void AddUpgrade(int upgradeNum)
    {
        canChange = true;
        upgrade += upgradeNum;
    }

    void ShowArrow()
    {
        yPos = ship.ships[ship.activeShip].transform.position.y + 0.5f;
        xPos = ship.ships[ship.activeShip].transform.position.x;
        playerPos = new Vector2(xPos, yPos);
        upgradeArrow.transform.SetPositionAndRotation(playerPos, Quaternion.identity);
        upgradeArrow.SetActive(true);
    }

    void ArrowGone()
    {
        upgradeArrow.SetActive(false);
    }
}
