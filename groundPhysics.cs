using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D playerRb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = null;
        }
    }

    void Update()
    {
        if (playerRb != null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
        }
    }
}
