using UnityEngine;

public class ShipStuff : MonoBehaviour
{
    public int activeShip;
    public bool shipSwitch;
    public int lastGun;
    CheatsEnable cheating;
    Vector2 lastPos;
    public Respawn[] ships;
    public int tempLives;

    int tabNum;
    public bool shield;
    public bool below6;

    private void Start()
    {
        cheating = FindObjectOfType<CheatsEnable>();
    }

    private void Update()
    {
        if (cheating.canCheat)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                shipSwitch = !shipSwitch;
                ships[activeShip].gunSwitch = false;
            }

            if (shipSwitch)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SwitchShip(0);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    SwitchShip(1);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    SwitchShip(2);
                }
                else
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    SwitchShip(3);
                }
                else
                if (Input.GetKeyDown(KeyCode.Tab) || Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    tabNum++;

                    if (tabNum < 0)
                    {
                        tabNum = 3;
                    }
                    else
                    if (tabNum > 3)
                    {
                        tabNum = 0;
                    }

                    SwitchShip(tabNum);
                }
                else
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    tabNum--;

                    if (tabNum < 0)
                    {
                        tabNum = 3;
                    }
                    else
                    if (tabNum > 3)
                    {
                        tabNum = 0;
                    }

                    SwitchShip(tabNum);
                }
            }
        }

        if (below6)
        {
            MoveAbove6();
        }
    }

    public void MoveAbove6()
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i].transform.position.y < -6)
            {
                ships[i].transform.position = ships[i].RespawnMove.position;
            }
        }
        below6 = false;
    }

    public void SwitchShip(int shipNum)
    {
        lastGun = ships[activeShip].activeGun;
        lastPos = ships[activeShip].gameObject.transform.position;
        tempLives = (int) ships[activeShip].GetComponent<PlayerCollision>().lives;
        ships[activeShip].gameObject.SetActive(false);
        activeShip = shipNum;
        ships[activeShip].gameObject.transform.position = lastPos;
        ships[activeShip].gameObject.SetActive(true);
        ships[activeShip].GetComponent<PlayerCollision>().lives = tempLives;
        ships[activeShip].SwitchGun(lastGun);
    }
}