using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBarForeground;
    private Player playerStats;

    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<Player>();
        maxHealth = playerStats.health;

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    public void addMaxHealth()
    {
        maxHealth = playerStats.health;
        UpdateHealthBar();
    }

    public void heal()
    {
        if (currentHealth < 100)
        {
            currentHealth++;
            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarForeground != null)
        {
            healthBarForeground.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
