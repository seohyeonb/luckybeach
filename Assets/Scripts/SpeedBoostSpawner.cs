using UnityEngine;
using System.Collections;

public class SpeedBoostSpawner : MonoBehaviour
{
    public GameObject speedBoostPrefab;

    public float spawnY = 6f;
    public float minX = -2.3f;
    public float maxX = 2.3f;

    public float minDelay = 5f;   // ⭐ 자주 안 나오게
    public float maxDelay = 9f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            Spawn();
        }
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        Vector2 pos = new Vector2(x, spawnY);

        Instantiate(speedBoostPrefab, pos, Quaternion.identity);
    }
}
