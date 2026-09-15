using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;
    private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private float speed;
    private void Awake()
    {
        controls = GetComponent<Controls>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector2 clampedMove = Vector2.ClampMagnitude(controls.Move(), 1f);
        velocity = clampedMove * speed;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}