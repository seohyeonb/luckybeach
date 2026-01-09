using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float minY = -12f; // ⭐ 너무 빨리 삭제 안 되게

    void Update()
    {
        // 아래로 이동
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // 화면 아래로 충분히 내려가면 삭제
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
