using UnityEngine;

public class Present : MonoBehaviour
{
    public string weaponName;
    public float fallingSpeed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fallingSpeed = -fallingSpeed;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, fallingSpeed);
    }
}
