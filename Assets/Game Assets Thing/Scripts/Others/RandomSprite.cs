using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
