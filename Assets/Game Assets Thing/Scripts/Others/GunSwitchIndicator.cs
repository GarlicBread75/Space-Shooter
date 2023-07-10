using UnityEngine;

public class GunSwitchIndicator : MonoBehaviour
{
    public Respawn[] pls;
    ShipStuff ship;

    private void Start()
    {
        ship = GameObject.Find("Ship Manager").GetComponent<ShipStuff>();
    }

    private void FixedUpdate()
    {
        if (ship.ships[ship.activeShip].gunSwitch)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
}
