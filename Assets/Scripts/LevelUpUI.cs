using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public GameObject levelUpPanel;
    public Button[] upgradeButtons;

    public Upgrade[] availableUpgrades; // <-- now it exists!

    private PlayerExperience player;


    void Start()
    {
        player = FindObjectOfType<PlayerExperience>();

        // Hide panel at start
        levelUpPanel.SetActive(false);
    }

    public void ShowLevelUp()
    {
        levelUpPanel.SetActive(true);
        Time.timeScale = 0f; // pause the game

        // Fill in buttons with upgrade info
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            if (i < availableUpgrades.Length)
            {
                Upgrade u = availableUpgrades[i];

                // Change button text
                Text[] texts = upgradeButtons[i].GetComponentsInChildren<Text>();
                if (texts.Length >= 2)
                {
                    texts[0].text = u.upgradeName;    // title
                    texts[1].text = u.description;   // description
                }

                // Optional: set icon if using an Image
                Image icon = upgradeButtons[i].GetComponentInChildren<Image>();
                if (u.icon != null && icon != null)
                    icon.sprite = u.icon;

                int index = i; // capture loop variable
                upgradeButtons[i].onClick.RemoveAllListeners();
                upgradeButtons[i].onClick.AddListener(() => ChooseUpgrade(index));
            }
        }
    }

    void ChooseUpgrade(int index)
    {
        Debug.Log("Chose upgrade: " + availableUpgrades[index].upgradeName);

        // Example actions
        if (availableUpgrades[index].upgradeName == "Orbiting Weapon")
        {
            // spawn orbiting weapon prefab
        }
        else if (availableUpgrades[index].upgradeName == "Extra Health")
        {
            player.GetComponent<PlayerHealth>().maxHealth += 20;
        }

        levelUpPanel.SetActive(false);
        Time.timeScale = 1f; // resume game
    }
}
