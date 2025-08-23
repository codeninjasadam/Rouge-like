using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // <-- add this

public class PlayerExperience : MonoBehaviour
{
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 50;

    public Slider xpSlider;     // drag XP bar here
    public TMP_Text levelText;  // TMP instead of Text
    public LevelUpUI levelUpUI; // assign in Inspector


    void Start()
    {
        UpdateUI();
    }

    public void GainXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }



    void LevelUp()
    {
        level++;
        currentXP -= xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f);

        Debug.Log("LEVEL UP! You are now level " + level);

        if (levelUpUI != null)
            levelUpUI.ShowLevelUp();
        else
            Debug.LogWarning("LevelUpUI reference is missing!");
    }



    void UpdateUI()
    {
        if (xpSlider != null)
        {
            xpSlider.maxValue = xpToNextLevel;
            xpSlider.value = currentXP;
        }

        if (levelText != null)
        {
            levelText.text = "Lvl " + level;
        }
    }
}
