using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("RigidBody")]
    public Rigidbody2D rb;

    public Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement.normalized);
    }
}
