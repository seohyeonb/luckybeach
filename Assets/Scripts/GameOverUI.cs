using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void Show(int finalScore)
    {
        panel.SetActive(true);
        scoreText.text = $"Score : {finalScore}";
    }

    public void Hide()
    {
        if (panel != null) panel.SetActive(false);
    }

    // 버튼용
    public void OnClickRestart()
    {
        GameManager.I.Restart();
    }

    public void OnClickMainMenu()
    {
        GameManager.I.GoMainMenu("MainMenu"); // 씬 이름 맞게!
    }

    public void OnClickPause()
    {
        GameManager.I.TogglePause();
    }
}
