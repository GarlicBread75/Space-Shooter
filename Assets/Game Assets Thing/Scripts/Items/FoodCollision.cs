using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    public FoodSpawn spawn;
    public float delay;
    AudioManager sound;

    private void Start()
    {
        Destroy(gameObject, delay);
        sound = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int num = Random.Range(0, 3);
            switch (num)
            {
                case 0:
                    sound.Play("Eating");
                    break;

                case 1:
                    sound.Play("Eating2");
                    break;

                case 2:
                    sound.Play("Eating3");
                    break;
            }
            spawn.foods.AddFood(1);
            spawn.score.AddScore(100);
            Destroy(gameObject);
        }
    }
}
