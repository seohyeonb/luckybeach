using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public int maxHits = 3;
    public int hitCount = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddHit()
    {
        if (isGameOver) return;

        hitCount++;
        Debug.Log($"Hit: {hitCount}/{maxHits}");

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
