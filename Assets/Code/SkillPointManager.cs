using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager : MonoBehaviour
{
    public GameObject skillPointMenu;
    private bool isMenuOpen = false;

    private Player playerStats;
    private PlayerHealth playerHealth;


    public TextMeshProUGUI skillPointsText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI fireSpeedText;

    public int skillPoints = 0;
    public int damage;
    public int health;
    public float fireSpeed;


    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<Player>();
        playerHealth = player.GetComponent<PlayerHealth>();
        damage = playerStats.damage;
        health = playerStats.health;
        fireSpeed = playerStats.fireSpeed;

        skillPointMenu.SetActive(isMenuOpen);
        UpdateSkillPointsText();
        UpdateStatsText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        skillPointMenu.SetActive(isMenuOpen);
    }

    public void AddDamage()
    {
        if (skillPoints > 0)
        {
            damage += 5;
            playerStats.damage = damage;
            SubtractSkillPoints();
        }
    }

    public void AddHealth()
    {
        if (skillPoints > 0)
        {
            health += 10;
            playerStats.health = health;
            playerHealth.addMaxHealth();
            SubtractSkillPoints();
        }
    }

    public void AddFireSpeed()
    {
        if (skillPoints > 0 && fireSpeed > .1)
        {
            fireSpeed -= .1f;
            playerStats.fireSpeed = fireSpeed;
            SubtractSkillPoints();
        }
    }

    public void AddSkillPoint()
    {
        skillPoints++;
        UpdateSkillPointsText();
    }

    public void SubtractSkillPoints()
    {
        if (skillPoints > 0)
        {
            skillPoints--;
            UpdateSkillPointsText();
            UpdateStatsText();
        }
    }

    public void UpdateStatsText()
    {
        damageText.text = "Damage: " + damage;
        healthText.text = "Health: " + health;
        fireSpeedText.text = "Fire Speed: " + (1.1 - fireSpeed).ToString("F1");
    }

    public void UpdateSkillPointsText()
    {
        skillPointsText.text = "Skill points: " + skillPoints;
    }
}