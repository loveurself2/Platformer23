using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreController scoreController = GameManager.instance.GetComponent<ScoreController>();

            scoreController.AddScore(coinValue);

            Destroy(gameObject);
        }
    }
}
