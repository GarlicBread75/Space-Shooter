using UnityEngine;

public class Rocket : MonoBehaviour
{
    RocketCounter counter;
    public float speed;
    public float multiplier;
    Vector2 direction;
    Vector2 target = Vector2.zero;
    AudioManager sound;

    [Header("The Big Boom")]
    public GameObject explosion;

    private void Start()
    {
        counter = FindObjectOfType<RocketCounter>();
        sound = FindObjectOfType<AudioManager>();
        counter.rocket--;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
        speed += Time.deltaTime * multiplier;

        direction = target - (Vector2)transform.position;
        transform.up = direction;

        if (transform.position == Vector3.zero)
        {
            sound.Stop("RocketLaunch");
            sound.Play("RocketExplode");
            GameObject destroyPls = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(destroyPls, 1f);

            foreach (GameObject thing in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                thing.GetComponent<EnemyHealth>().currentHp = 0;
            }

            foreach (GameObject thing in GameObject.FindGameObjectsWithTag("Boss"))
            {
                thing.GetComponent<BossHealth>().currentHp -= thing.GetComponent<BossHealth>().maxHp / 10;
            }

            foreach (GameObject thing in GameObject.FindGameObjectsWithTag("EnemyBullet"))
            {
                Destroy(thing);
            }

            Destroy(gameObject);
        }
    }
}
