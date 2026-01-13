using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float moveSpeed = 3f;          // ⭐ 배경/코인 속도랑 맞추기
    public float speedMultiplier = 5f;  // 빨라지는 배율
    public float boostDuration = 2f;

    void Update()
    {
        // ⭐ 코인/장애물처럼 아래로 이동
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // 화면 아래로 나가면 삭제
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            player.BoostSpeed(speedMultiplier, boostDuration);
        }

        Destroy(gameObject);
    }


}
