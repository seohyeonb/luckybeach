using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;        // Heart1,2,3
    [SerializeField] private Sprite fullHeart;      // 빨간 하트
    [SerializeField] private Sprite emptyHeart;     // 검은 하트

    public void SetLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite = fullHeart;   // 아직 살아있음
            }
            else
            {
                hearts[i].sprite = emptyHeart;  // 깎인 하트
            }
        }
    }
}
