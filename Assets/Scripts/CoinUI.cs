using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    TextMeshProUGUI coinText;
    void Awake()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // ⭐ GameManager 값 그대로 표시
        coinText.text = GameManager.I.coinCount.ToString();
    }
}
