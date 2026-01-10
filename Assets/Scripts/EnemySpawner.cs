using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs; // ← 배열 이름 복수형 권장

    public float spawnY = 6f;
    public float minX = -2.3f;
    public float maxX = 2.3f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // 1초, 2초, 3초 중 랜덤
            float delay = Random.Range(1, 4);
            yield return new WaitForSeconds(delay);

            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // 🔥 핵심: 배열에서 하나 랜덤 선택
        int index = Random.Range(0, enemyPrefabs.Length);

        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
    }
}
