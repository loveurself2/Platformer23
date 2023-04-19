using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
    public Sprite[] idleSprites;
    public float animationSpeed = 0.2f;

    private SpriteRenderer spriteRenderer;

    private float animationTimer = 0f;
    private int currentSpriteIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprites[0];
    }

    void Update()
    {
        animationTimer += Time.deltaTime;

        if (animationTimer >= animationSpeed)
        {
            animationTimer = 0f;

            currentSpriteIndex++;
            if (currentSpriteIndex >= idleSprites.Length)
            {
                currentSpriteIndex = 0;
            }

            spriteRenderer.sprite = idleSprites[currentSpriteIndex];
        }
    }
}
