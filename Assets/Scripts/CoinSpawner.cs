using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float spawnY = 6f;
    public float minX = -2.3f;
    public float maxX = 2.3f;

    // 스폰 간격
    public float minSpawnDelay = 0.8f;
    public float maxSpawnDelay = 1.5f;

    // 세로 간격
    public float verticalSpacing = 0.6f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            SpawnVerticalCoins();
        }
    }

    void SpawnVerticalCoins()
    {
        // 1~3개 중 랜덤
        int count = Random.Range(1, 4);

        float x = Random.Range(minX, maxX);

        for (int i = 0; i < count; i++)
        {
            float y = spawnY + i * verticalSpacing;
            Vector2 pos = new Vector2(x, y);

            Instantiate(coinPrefab, pos, Quaternion.identity);
        }
    }
}
