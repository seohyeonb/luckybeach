using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
<<<<<<< Updated upstream
    [SerializeField] private float destroyY = -6f;

=======
    [SerializeField] private float minY = -12f; // ⭐ 너무 빨리 삭제 안 되게
    Rigidbody2D rb;
    void Awake(){
        rb=GetComponent<Rigidbody2D>();
    }
       
>>>>>>> Stashed changes
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
