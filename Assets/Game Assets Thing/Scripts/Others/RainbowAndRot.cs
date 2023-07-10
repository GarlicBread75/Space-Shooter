using UnityEngine;

public class RainbowAndRot : MonoBehaviour
{
    float hue;
    public float modifier;
    float rot;
    public float modify;

    public bool canColour;
    public bool canRot;

    private void Start()
    {
        hue = Random.Range(0f, 1f);
        rot = Random.Range(0f, 360f);
    }

    void Update()
    {
        if (canColour)
        {
            if (hue > 1f)
            {
                hue = 0;
            }
            else
            {
                hue += Time.deltaTime / modifier;
            }

            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, 1f, 1f);
        }

        if (canRot)
        {
            if (rot > 1440)
            {
                rot = 0;
            }
            else
            {
                rot += Time.deltaTime / modify;
            }

            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }
}
