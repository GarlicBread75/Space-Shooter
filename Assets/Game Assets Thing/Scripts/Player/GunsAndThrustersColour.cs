using UnityEngine;

public class GunsAndThrustersColour : MonoBehaviour
{
    public SpriteRenderer spriteColour;
    public SpriteRenderer[] gunColour;
    public Respawn thing;

    void FixedUpdate()
    {
        spriteColour.color = gunColour[thing.activeGun].color;
    }
}
