using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;  // <-- add this

public class LevelUpUI : MonoBehaviour
{
    public GameObject levelUpPanel;
    public List<Button> optionButtons;

    private WeaponManager weaponManager;

    void Start()
    {
        levelUpPanel.SetActive(false);
        weaponManager = FindObjectOfType<WeaponManager>();

        // Assign button listeners
        for (int i = 0; i < optionButtons.Count; i++)
        {
            int index = i; // capture index
            optionButtons[i].onClick.AddListener(() => ChooseOption(index));
        }
    }

    // Call this from PlayerExperience when leveling up
    public void ShowLevelUp()
    {
        // Enable panel
        levelUpPanel.SetActive(true);

        // Set button texts (example: can randomize upgrades)
        for (int i = 0; i < optionButtons.Count; i++)
        {
            optionButtons[i].GetComponentInChildren<TMP_Text>().text = "Upgrade Weapon " + (i+1);
        }

        // Pause game while choosing
        Time.timeScale = 0f;
    }

    void ChooseOption(int index)
    {
        Time.timeScale = 1f; // unpause

        // Upgrade weapon if exists
        if (weaponManager != null && weaponManager.equippedWeapons.Count > index)
        {
            weaponManager.equippedWeapons[index].UpgradeWeapon();
        }

        // Hide panel
        levelUpPanel.SetActive(false);
    }
}
