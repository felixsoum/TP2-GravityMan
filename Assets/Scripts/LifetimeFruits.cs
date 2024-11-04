using TMPro;
using UnityEngine;

public class LifetimeFruits : MonoBehaviour
{
    private const string FruitKey = "TOTAL_FRUITS";
    TMP_Text totalText;
    int totalFruitsCollectedInLifetime;
    private void Start()
    {
        totalText = GetComponent<TMP_Text>();
        totalFruitsCollectedInLifetime = PlayerPrefs.GetInt(FruitKey);
        UpdateText();
    }

    internal void CollectFruit()
    {
        totalFruitsCollectedInLifetime++;
        PlayerPrefs.SetInt(FruitKey, totalFruitsCollectedInLifetime);
        UpdateText();
    }

    private void UpdateText()
    {
        totalText.text = "Total fruits: " + totalFruitsCollectedInLifetime;
    }



}
