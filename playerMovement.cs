using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    private Rigidbody2D rb;
    private bool isGrounded = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>("Square");
    }
    
    void Update()
    {
        // Move the player horizontally
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        
        // Check if the player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        isGrounded = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                isGrounded = true;
                break;
            }
        }
        
        // Jump if the player is grounded and the jump button is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
