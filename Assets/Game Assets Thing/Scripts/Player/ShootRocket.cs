using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    public GameObject rocket;
    RocketCounter counter;
    CheatsEnable cheating;
    AudioManager sound;

    private void Start()
    {
        counter = FindObjectOfType<RocketCounter>();
        cheating = FindObjectOfType<CheatsEnable>();
        sound = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1)) && counter.rocket >= 1)
            {
                sound.Play("RocketLaunch");
                Instantiate(rocket, transform.position, Quaternion.identity);
            }
            else
            if (cheating.canCheat)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    counter.rocket++;
                }
            }
        }
    }
}
