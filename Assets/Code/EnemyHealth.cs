using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image healthBarForeground;

    public float currentHealth;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
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

    void UpdateHealthBar()
    {
        if (healthBarForeground != null)
        {
            healthBarForeground.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
