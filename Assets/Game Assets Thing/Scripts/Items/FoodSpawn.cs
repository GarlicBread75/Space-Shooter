using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public Sprite[] foodSprites;

    [HideInInspector] public FoodCounter foods;
    [HideInInspector] public ScoreCounter score;
    Rigidbody2D rb;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];

        foods = GameObject.Find("FCO").GetComponent<FoodCounter>();
        score = GameObject.Find("SCO").GetComponent<ScoreCounter>();
        rb = GetComponent<Rigidbody2D>();

        Vector2 dropDirection = new Vector2 (Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.AddForce(dropDirection * Random.Range(0f, 5f), ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(0f, 1.5f), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.AddTorque(-Time.fixedDeltaTime, ForceMode2D.Force);
    }
}
