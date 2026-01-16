using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("Score")]
    public int score = 0;
    public Text scoreText;

    [Header("Coin")]
    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    [Header("Hits / Lives")]
    public int maxHits = 3;
    public int hitCount = 0;
    private bool isGameOver = false;

    [Header("UI")]
    [SerializeField] private LivesUI livesUI;

    private void Awake()
    {
        if (I != null)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // 시작 시 하트 초기화
        if (livesUI != null)
            livesUI.SetLives(maxHits - hitCount);

        // 텍스트 초기화
        UpdateScoreText();
        UpdateCoinText();
    }

    // ================== HIT ==================
    public void AddHit()
    {
        if (isGameOver) return;

        hitCount++;
        Debug.Log($"Hit: {hitCount}/{maxHits}");

        if (livesUI != null)
            livesUI.SetLives(maxHits - hitCount);
    }

    // ================== SCORE ==================
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    // ================== COIN ==================
    public void AddCoin(int value)
    {
        coinCount += value;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = $"{coinCount}";
    }
}
