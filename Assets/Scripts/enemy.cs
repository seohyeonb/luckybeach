using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float destroyY = -6f;

    void Update()
    {
        // 아래로 이동 (배경과 반대 방향으로 "지나가는 느낌")
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // 화면 아래로 나가면 삭제
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}
