// 5/8/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System.Collections;
using UnityEngine;

public class RandomSpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites; // Array of sprites to choose from
    public float changeInterval = 0.5f; // Interval to change sprites
    public bool toggleChangingSprites = true;

    private SpriteRenderer spriteRenderer; // Reference to the Sprite Renderer component

    private void Start()
    {
        // Get the Sprite Renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start the sprite changing coroutine
        StartCoroutine(ChangeSprite());
    }

    private IEnumerator ChangeSprite()
    {
        while (toggleChangingSprites)
        {
            // Select a random sprite
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

            // Wait for the specified interval
            yield return new WaitForSeconds(changeInterval);
        }
    }
}