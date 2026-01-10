using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int scoreValue = 1;

    void Update()
    {
        // 아래로 계속 이동
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // 화면 아래로 벗어나면 삭제
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.I.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
