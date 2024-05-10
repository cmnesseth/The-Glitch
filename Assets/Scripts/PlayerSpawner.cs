// 5/9/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public float spawnDelay = 5f;
    public float spawnScaleTime = 3f;

    void Start()
    {
        // Make sure the player is initially disabled
        player.SetActive(false);

        // Start the spawn coroutine
        StartCoroutine(EnableAndScalePlayer());
    }

    IEnumerator EnableAndScalePlayer()
    {
        yield return new WaitForSeconds(spawnDelay);

        // Enable the player
        player.SetActive(true);

        // **CMN** Store any preset localScale transforms before zeroing scale
        Vector3 playerScale = player.transform.localScale;

        player.transform.localScale = Vector3.zero;
        float elapsedTime = 0f;
        while (elapsedTime < spawnScaleTime)
        {
            // **CMN** Linearly interpolate between 0 and its preset scale
            player.transform.localScale = Vector3.Lerp(Vector3.zero, playerScale, elapsedTime / spawnScaleTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.localScale = playerScale;
    }
}