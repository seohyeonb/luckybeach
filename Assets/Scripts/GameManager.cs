using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("Hits / Lives")]
    public int maxHits = 3;
    public int hitCount = 0;
    private bool isGameOver = false;

    [Header("UI")]
    [SerializeField] private LivesUI livesUI; // ⭐ 추가

    private void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // 시작 시 하트 3개 꽉 채우기
        if (livesUI != null)
            livesUI.SetLives(maxHits - hitCount); // 처음엔 3
    }

    public void AddHit()
    {
        if (isGameOver) return;

        hitCount++;
        Debug.Log($"Hit: {hitCount}/{maxHits}");

        // ⭐ 하트 갱신 (남은 목숨 = maxHits - hitCount)
        if (livesUI != null)
            livesUI.SetLives(maxHits - hitCount);

        if (hitCount >= maxHits)
        {
            isGameOver = true;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        hitCount = 0;
        isGameOver = false;

        // ⭐ 하트 초기화
        if (livesUI != null)
            livesUI.SetLives(maxHits);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
