using UnityEngine;

public class RandomColour : MonoBehaviour
{
    SpriteRenderer colour;
    public bool continuousChange;
    public bool canChange;
    private float timer;
    public float changeRate;

    void Start()
    {
        colour = GetComponent<SpriteRenderer>();

        if (!continuousChange)
        {
            colour.color = Random.ColorHSV(0, 1, 0.2f, 1, 0.4f, 1);
        }
    }

    void FixedUpdate()
    {
        if (continuousChange)
        {
            if (!canChange)
            {
                timer += Time.fixedDeltaTime;
                if (timer > changeRate)
                {
                    canChange = true;
                    timer = 0;
                }
            }

            if (canChange)
            {
                canChange = false;
                colour.color = Random.ColorHSV(0, 1, 0.2f, 1, 0.4f, 1);
            }
        }
    }
}
