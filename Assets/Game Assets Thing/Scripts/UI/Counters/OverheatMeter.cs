using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverheatMeter : MonoBehaviour
{
    public Slider slider;
    public float heatDecrease;
    public bool inCooldown = false;
    public Image fill;
    public TextMeshProUGUI text;

    ShipStuff ship;
    Respawn currentShip;
    public Respawn[] pls;
    Gun currentGun;
    AudioManager sound;
    Vector2 playerPos;
    float yPos;
    float xPos;

    bool canPlay = true;

    private void Start()
    {
        ship = FindObjectOfType<ShipStuff>();
        currentShip = ship.ships[ship.activeShip];
        currentGun = currentShip.guns[currentShip.activeGun];
        sound = FindObjectOfType<AudioManager>();
    }

    private void FixedUpdate()
    {
        if (slider.value == slider.maxValue)
        {
            fill.GetComponent<Image>().color = Color.gray;
            inCooldown = true;
            currentGun.canShoot = false;
            sound.Play("Overheat");
            ShowText();
            Invoke(nameof(TextGone), 2f);
        }
        else
        if (slider.value >= 80 && canPlay)
        {
            sound.Play("Overheat Warning");
            canPlay = false;
        }
        else
        if (slider.value < 71 && !canPlay)
        {
            canPlay = true;
        }
        else
        if (slider.value == 0 && inCooldown)
        {
            fill.GetComponent<Image>().color = Color.white;
            inCooldown = false;
            currentGun.canShoot = true;
            canPlay = true;
        }

        if (!inCooldown)
        {
            slider.value -= Time.deltaTime * heatDecrease;
        }
        else
        {
            slider.value -= Time.deltaTime * heatDecrease * 2f;
        }

        if (text.gameObject.activeInHierarchy)
        {
            yPos += Time.deltaTime;
            text.transform.position = new Vector2 (xPos, yPos);
        }
    }

    void ShowText()
    {
        yPos = ship.ships[ship.activeShip].transform.position.y + 0.5f;
        xPos = ship.ships[ship.activeShip].transform.position.x;
        playerPos = new Vector2 (xPos, yPos);
        text.transform.SetPositionAndRotation(playerPos, Quaternion.identity);
        text.gameObject.SetActive(true);
    }

    void TextGone()
    {
        text.gameObject.SetActive(false);
    }
}
