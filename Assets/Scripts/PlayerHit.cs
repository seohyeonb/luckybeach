using System.Collections;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] float invincibleTime = 1f;
    [SerializeField] float blinkInterval = 0.08f;
    [SerializeField] float startGraceTime = 0.15f;

    bool invincible = false;
    bool canBeHit = false;

    Collider2D hitbox;
    SpriteRenderer sr;
    Color originColor;

    void Awake()
    {
        hitbox = GetComponent<Collider2D>();
        sr = GetComponentInParent<SpriteRenderer>();
        originColor = sr.color;
    }

    IEnumerator Start()
    {
        hitbox.enabled = false;
        canBeHit = false;

        yield return new WaitForSeconds(startGraceTime);

        hitbox.enabled = true;
        yield return null;          // ⭐ 한 프레임 보호
        canBeHit = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.I.IsPlaying()) return;
        if (!canBeHit) return;
        if (invincible) return;

        if (other.CompareTag("Enemy"))
        {
            GameManager.I.AddHit();
            StartCoroutine(InvincibleRoutine());
        }
    }

    IEnumerator InvincibleRoutine()
    {
        invincible = true;
        hitbox.enabled = false;

        float t = 0f;
        bool redOn = false;

        while (t < invincibleTime)
        {
            redOn = !redOn;
            sr.color = redOn ? Color.red : originColor;

            yield return new WaitForSecondsRealtime(blinkInterval);
            t += blinkInterval;
        }

        sr.color = originColor;
        hitbox.enabled = true;
        invincible = false;
    }
}
