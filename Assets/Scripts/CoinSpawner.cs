using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float spawnY = 6f;
    public float minX = -2.3f;
    public float maxX = 2.3f;

    public float spawnInterval = 1.2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}
