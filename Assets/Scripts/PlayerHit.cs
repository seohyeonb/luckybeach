using System.Collections;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] float invincibleTime = 1.0f;
    [SerializeField] float blinkInterval = 0.08f;
    [SerializeField] float startGraceTime = 0.15f; // ⭐ 시작 직후 오작동 방지

    bool invincible = false;
    Collider2D hitbox;
    SpriteRenderer sr;
    Color originColor;
    bool canBeHit = false;

    void Awake()
    {
        hitbox = GetComponent<Collider2D>();          // Hitbox(Trigger)
        sr = GetComponentInParent<SpriteRenderer>();  // 플레이어 본체 스프라이트
        originColor = sr.color;
    }

    IEnumerator Start()
    {
        // 시작하자마자 겹쳐있는 애들 때문에 Enter가 떠버리는 경우가 있음
        hitbox.enabled = false;
        yield return new WaitForSeconds(startGraceTime);
        hitbox.enabled = true;
        canBeHit = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBeHit) return;
        if (invincible) return;

        // ⭐ Enemy = 장애물 = 하트 깎는 대상
        if (other.CompareTag("Enemy"))
        {
            GameManager.I.AddHit();;  // 하트 감소
            StartCoroutine(InvincibleRoutine()); // 빨간 깜빡 + 무적
        }
    }

    IEnumerator InvincibleRoutine()
    {
        invincible = true;
        hitbox.enabled = false; // 무적 동안 추가 피격 방지

        float t = 0f;
        bool redOn = false;

        while (t < invincibleTime)
        {
            redOn = !redOn;

            var c = originColor;
            if (redOn)
            {
                // 빨강으로 깜빡 (원래 알파 유지)
                c.r = 1f; c.g = 0f; c.b = 0f;
            }
            sr.color = c;

            yield return new WaitForSeconds(blinkInterval);
            t += blinkInterval;
        }

        sr.color = originColor;
        hitbox.enabled = true;
        invincible = false;
    }
}
