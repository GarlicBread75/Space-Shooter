using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Sprite[] sprites;
    MainMenu menu;

    private void Start()
    {
        menu = FindObjectOfType<MainMenu>();
    }

    void FixedUpdate()
    {
        if (menu.isSoundOn)
        {
            gameObject.GetComponent<Image>().sprite = sprites[0];
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sprites[1];
        }
    }
}
