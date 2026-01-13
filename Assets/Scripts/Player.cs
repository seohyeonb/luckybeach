using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;

    private float originalSpeed;

    void Start()
    {
        // ⭐ 처음 속도를 기준값으로 저장
        originalSpeed = moveSpeed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }

    public void BoostSpeed(float multiplier, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(BoostRoutine(multiplier, duration));
    }

    IEnumerator BoostRoutine(float multiplier, float duration)
    {
        moveSpeed = originalSpeed * multiplier;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
    }
}
