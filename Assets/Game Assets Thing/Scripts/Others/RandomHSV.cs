using UnityEngine;

public class RandomHSV : MonoBehaviour
{
    public float hue;

    void Start()
    {
        if (gameObject.name == "Black_Enemy" || gameObject.name == "Black_Boss")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, 0, Random.Range(0.8f, 1f));
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, Random.Range(0f, 0.4f), Random.Range(0.8f, 1f));
        }
    }
}
