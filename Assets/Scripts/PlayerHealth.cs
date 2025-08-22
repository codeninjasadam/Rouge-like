using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // for restarting

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider; // drag UI Slider here
    public GameObject gameOverScreen; // drag GameOver panel here

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        // Stop time so enemies freeze
        Time.timeScale = 0f;
    }
}

