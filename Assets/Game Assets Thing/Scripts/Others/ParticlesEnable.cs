using UnityEngine;

public class ParticlesEnable : MonoBehaviour
{
    public ParticleSystem stars;
    public ParticleSystem asteroids;

    private void OnEnable()
    {
        stars.Play();
        asteroids.Play();
    }
}
