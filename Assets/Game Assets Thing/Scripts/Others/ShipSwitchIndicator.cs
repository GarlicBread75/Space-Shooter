using UnityEngine;

public class ShipSwitchIndicator : MonoBehaviour
{
    ShipStuff ship;

    private void Start()
    {
        ship = GameObject.Find("Ship Manager").GetComponent<ShipStuff>();
    }

    private void FixedUpdate()
    {
        if (ship.shipSwitch)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
}
