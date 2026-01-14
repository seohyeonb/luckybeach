using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public enum GameState { Playing, GameOver, Paused }
    public GameState state = GameState.Playing;

    [Header("Hits / Lives")]
    public int maxHits = 3;
    public int hitCount = 0;

    [Header("Score")]
    public int score = 0;
    [Header("Coin")]
    public int coinCount = 0;


    [Header("UI (optional in Inspector)")]
    [SerializeField] private LivesUI livesUI;
    [SerializeField] private GameOverUI gameOverUI;

    private void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);

        // ✅ 씬 로드될 때마다 UI 다시 연결
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        if (I == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        ResetRun();
        BindUI();
        if (livesUI != null) livesUI.SetLives(maxHits);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 바뀌거나 Restart로 다시 로드되면 UI 참조 다시 잡기
        BindUI();

        // 새 씬에서 게임은 기본 Playing으로 시작
        Time.timeScale = 1f;
        state = GameState.Playing;

        if (livesUI != null) livesUI.SetLives(maxHits - hitCount);
        if (gameOverUI != null) gameOverUI.Hide(); // 재시작 시 팝업 숨김
    }

    private void BindUI()
    {
        // Inspector에 연결 안 되어 있으면 자동으로 찾기
        if (livesUI == null) livesUI = FindAnyObjectByType<LivesUI>();
        if (gameOverUI == null) gameOverUI = FindAnyObjectByType<GameOverUI>();
    }

    private void ResetRun()
    {
        hitCount = 0;
        score = 0;
        state = GameState.Playing;
    }

    public bool IsPlaying() => state == GameState.Playing;

    public void AddScore(int amount)
    {
        if (!IsPlaying()) return;
        score += amount;
    }

    public void AddHit()
    {
        if (!IsPlaying()) return;

        hitCount++;
        if (livesUI != null) livesUI.SetLives(maxHits - hitCount);

        if (hitCount >= maxHits)
            SetGameOver();
    }

    private void SetGameOver()
    {
        state = GameState.GameOver;

        // ✅ UI 먼저 띄우기(혹시 timeScale 이슈로 연출 꼬일까봐)
        BindUI();
        if (gameOverUI != null)
            gameOverUI.Show(score);
        else
            Debug.LogError("GameOverUI를 찾지 못했어! (씬에 GameOverUI가 붙은 오브젝트가 있어야 해)");

        // ✅ 그 다음 게임 멈춤
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ResetRun();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        ResetRun();
        SceneManager.LoadScene(sceneName);
    }

    public void TogglePause()
    {
        if (state == GameState.GameOver) return;

        if (state == GameState.Paused)
        {
            state = GameState.Playing;
            Time.timeScale = 1f;
        }
        else
        {
            state = GameState.Paused;
            Time.timeScale = 0f;
        }
    }
    

    public void AddCoin(int amount = 1)
    {
        coinCount += amount;
    }


}
