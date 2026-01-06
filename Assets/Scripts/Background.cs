using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
