// 5/8/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;
using System.Collections;

public class TextureTransition : MonoBehaviour
{
    public Material dissolveMaterial;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TransitionToNextSprite());
    }

    IEnumerator TransitionToNextSprite()
    {
        float transitionDuration = 1f; // Duration of the transition in seconds
        float startTime = Time.time;

        // Dissolve out
        while (Time.time < startTime + transitionDuration)
        {
            float t = (Time.time - startTime) / transitionDuration;
            dissolveMaterial.SetFloat("_DissolveThreshold", t);
            yield return null;
        }

        // Switch to next sprite
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentSpriteIndex];

        // Dissolve in
        startTime = Time.time;
        while (Time.time < startTime + transitionDuration)
        {
            float t = 1 - (Time.time - startTime) / transitionDuration;
            dissolveMaterial.SetFloat("_DissolveThreshold", t);
            yield return null;
        }

        // Prepare for the next transition
        yield return new WaitForSeconds(1f); // Wait for 1 second before next transition
        StartCoroutine(TransitionToNextSprite());
    }
}