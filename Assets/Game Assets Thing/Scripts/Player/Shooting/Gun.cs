using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] firePoint;
    public OverheatMeter heat;
    public Respawn thing;
    AudioManager sound;
    public bool canShoot;
    public float fireRate;
    public float heatIncrease;
    private float timer;
    bool isPlaying1;
    bool isPlaying2;
    bool isPlaying3;
    bool isPlaying4;
    bool isPlaying5;
    public GameObject steam;
    public LineRend[] lr;
    public float heatBuildUp;
    public float heatModifier;

    public bool laser;
    public bool plasma;

    public float lrDmg;


    private void Start()
    {
        sound = FindObjectOfType<AudioManager>();
        heatBuildUp = heatIncrease;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (!canShoot)
            {
                timer += Time.fixedDeltaTime;
                if (timer > fireRate)
                {
                    canShoot = true;
                    timer = 0;
                }
            }

            if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && canShoot && !heat.inCooldown)
            {
                canShoot = false;
                for (int i = 0; i < firePoint.Length; i++)
                {
                    if (!laser && !plasma)
                    {
                        lr[i].shoot = false;
                        Instantiate(bullet, firePoint[i].position, Quaternion.identity);
                    }
                    else
                    if (laser)
                    {
                        lr[i].shoot = true;
                        lr[i].plasma = false;
                        lr[i].laser = true;
                        lr[i].RayDmg(lrDmg);

                        Invoke(nameof(LRStop), 0.1f);
                    }
                    else
                    if (plasma)
                    {
                        lr[i].shoot = true;
                        lr[i].laser = false;
                        lr[i].plasma = true;
                        lr[i].RayDmg(lrDmg);
                    }
                }

                heat.slider.value += heatBuildUp;
                heatBuildUp += Time.deltaTime * heatModifier;

                if (gameObject.name == "Ion Blaster")
                {
                    sound.Stop("Plasma");
                    if (isPlaying1)
                    {
                        sound.Play("Ion");
                        isPlaying1 = !isPlaying1;
                    }
                    else
                    {
                        sound.Play("Ion2");
                        isPlaying1 = !isPlaying1;
                    }
                }
                else
                if (gameObject.name == "Neutron Gun")
                {
                    sound.Stop("Plasma");
                    sound.Play("Neutron");
                }
                else
                if (gameObject.name == "Laser Cannon")
                {
                    sound.Stop("Plasma");
                    if (isPlaying2)
                    {
                        sound.Play("Laser");
                        isPlaying2 = !isPlaying2;
                    }
                    else
                    {
                        sound.Play("Laser2");
                        isPlaying2 = !isPlaying2;
                    }
                }
                else
                if (gameObject.name == "Vulcan Chaingun")
                {
                    sound.Stop("Plasma");
                    if (isPlaying3)
                    {
                        sound.Play("Vulcan");
                        isPlaying3 = !isPlaying3;
                    }
                    else
                    if (isPlaying4)
                    {
                        sound.Play("Vulcan2");
                        isPlaying4 = !isPlaying4;
                    }
                    else
                    {
                        sound.Play("Vulcan3");
                        isPlaying3 = !isPlaying3;
                        isPlaying4 = !isPlaying4;
                    }
                }
                else
                if (gameObject.name == "Plasma Rifle")
                {
                    sound.IsPlaying("Plasma");
                }
                else
                if (gameObject.name == "Utensil Poker")
                {
                    sound.Stop("Plasma");
                    if (isPlaying5)
                    {
                        sound.Play("Fork");
                        isPlaying5 = !isPlaying5;
                    }
                    else
                    {
                        sound.Play("Fork2");
                        isPlaying5 = !isPlaying5;
                    }
                }
            }

            if (heat.slider.value == 100)
            {
                Invoke(nameof(LRStop), 0.075f);
                GameObject destroyPls = Instantiate(steam, new Vector2(transform.position.x, transform.position.y + 0.15f), Quaternion.identity);
                Destroy(destroyPls, 2f);
                heatBuildUp = heatIncrease;

                if (gameObject.name == "Plasma Rifle")
                {
                    sound.Stop("Plasma");
                }
            }

            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                sound.Stop("Plasma");
                for (int i = 0; i < lr.Length; i++)
                {
                    lr[i].shoot = false;
                }
                heatBuildUp = heatIncrease;
            }
        }
    }

    void LRStop()
    {
        for (int i = 0; i < lr.Length; i++)
        {
            lr[i].shoot = false;
        }
    }
}
