using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;
    public float moveSpeed = 3f;
    public float spawnY = 8f;


    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player랑 부딪혔을 때만
        if (!other.CompareTag("Player")) return;

        // GameManager 안전 체크
        if (GameManager.I == null)
        {
            Debug.LogError("❌ GameManager.I is NULL");
            return;
        }
        GameManager.I.AddCoin(1);

        // 점수 +1
        GameManager.I.AddScore(scoreValue);

        // 코인 제거
        Destroy(gameObject);
    }
}
