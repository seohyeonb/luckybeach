using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene"); // 게임 씬 이름
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
