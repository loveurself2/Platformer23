using UnityEngine;

public class WallController : MonoBehaviour
{
    public float wallJumpForce = 10f;
    public float wallSlideSpeed = 2f;

    private bool isPlayerNear = false;
    private Rigidbody2D playerRb;
    private bool isJumping = false;
    private bool isWallSliding = false;
    private Vector2 wallNormal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            playerRb = other.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear)
        {
            // Check if the player is pressing the jump button
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }
        }

        if (isJumping)
        {
            // Apply a wall jump force to the player
            playerRb.velocity = new Vector2(wallNormal.x * -wallJumpForce, wallJumpForce);
            isJumping = false;
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            // Apply a wall slide speed to the player
            playerRb.velocity = new Vector2(playerRb.velocity.x, -wallSlideSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (isPlayerNear && !isJumping)
        {
            // Check if the player collided with the wall
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > 0.5f)
                {
                    isWallSliding = true;
                    wallNormal = contact.normal;
                    break;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (isWallSliding)
        {
            // Stop the wall slide if the player leaves the wall
            isWallSliding = false;
        }
    }
}
