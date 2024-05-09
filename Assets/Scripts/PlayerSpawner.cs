// 5/9/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 5f;
    public float spawnScaleTime = 3f;

    void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        player.transform.localScale = Vector3.zero;

        float elapsedTime = 0f;
        while (elapsedTime < spawnScaleTime)
        {
            player.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime / spawnScaleTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.localScale = Vector3.one;
    }
}