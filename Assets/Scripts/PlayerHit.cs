using System.Collections;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float invincibleTime = 0.8f;
    public float blinkInterval = 0.1f;

    private bool invincible = false;
    private SpriteRenderer sr;
    private Color originalColor;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        Debug.Log("[PlayerHit] Awake. SpriteRenderer = " + (sr ? sr.name : "NULL"));

        if (sr != null) originalColor = sr.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("[PlayerHit] Trigger with: " + other.name + " tag=" + other.tag);

        if (invincible) return;

        // 태그가 정확히 cat_orange 맞는지 확인용으로 태그 체크 잠깐 완화
        if (other.CompareTag("cat_orange"))
        {
            Debug.Log("[PlayerHit] CAT HIT -> BLINK!");
            StartCoroutine(RedBlinkInvincible());
        }
    }

    private IEnumerator RedBlinkInvincible()
    {
        invincible = true;

        float t = 0f;
        bool isRed = false;

        while (t < invincibleTime)
        {
            t += blinkInterval;
            isRed = !isRed;

            if (sr != null)
            {
                // 눈에 확 띄게 마젠타로 테스트 (레드가 티 안 나면 이게 확실함)
                sr.color = isRed ? Color.magenta : originalColor;
            }

            yield return new WaitForSeconds(blinkInterval);
        }

        if (sr != null) sr.color = originalColor;
        invincible = false;
    }
}
