using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;
    private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite[] walkSprites;
    [SerializeField, Min(0.1f)] private float walkFramesPerSecond = 8f;
    private float walkTime;
    private void Awake()
    {
        controls = GetComponent<Controls>();
        rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateAnimation(controls.Move(), Time.deltaTime);
    }

    private void UpdateAnimation(Vector2 move, float deltaTime)
    {
        if (spriteRenderer == null)
            return;

        if (move.sqrMagnitude < 0.0001f)
        {
            walkTime = 0f;
            spriteRenderer.sprite = idleSprite;
            return;
        }

        if (Mathf.Abs(move.x) > 0.01f)
            spriteRenderer.flipX = move.x < 0f;

        if (walkSprites == null || walkSprites.Length == 0)
        {
            spriteRenderer.sprite = idleSprite;
            return;
        }

        int frame = Mathf.FloorToInt(walkTime * walkFramesPerSecond) % walkSprites.Length;
        spriteRenderer.sprite = walkSprites[frame];
        walkTime = (walkTime + deltaTime) % (walkSprites.Length / walkFramesPerSecond);
    }


    private void FixedUpdate()
    {
        Vector2 clampedMove = Vector2.ClampMagnitude(controls.Move(), 1f);
        velocity = clampedMove * speed;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
