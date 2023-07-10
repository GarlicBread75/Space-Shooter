using TMPro;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    private int lives;
    ShipStuff ship;

    private void Start()
    {
        ship = GameObject.Find("Ship Manager").GetComponent<ShipStuff>();
    }

    void FixedUpdate()
    {
        lives = (int) ship.ships[ship.activeShip].GetComponent<PlayerCollision>().lives;

        if (lives <= 0)
        {
            lives = 0;
        }
        
        ShowLives();
    }

    public void ShowLives()
    {
        counter.text = lives.ToString();
    }

    public void AddLives(int livesNum)
    {
        ship.ships[ship.activeShip].GetComponent<PlayerCollision>().lives += livesNum;
    }
}
