using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnInterval = 0.2f;

    [SerializeField] private float minX = -2.2f; // 왼쪽 한계
    [SerializeField] private float maxX = 2.2f; // 오른쪽 한계
    [SerializeField] private int spawnCount = 5; // 한 번에 몇 개

    IEnumerator Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            int enemyIndex = Random.Range(0, enemies.Length);
            float randomX = Random.Range(minX, maxX);

            SpawnEnemy(randomX, enemyIndex);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(
            posX,
            8f,     // 화면 위
            -1f
        );

        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
}
