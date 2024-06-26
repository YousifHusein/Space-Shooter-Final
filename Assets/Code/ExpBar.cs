using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Image expBarForeground;
    public Text levelText;

    private float currentExp = 0f;
    private float maxExp = 100f;
    private int currentLevel = 1;

    public SkillPointManager skillPointManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateExpBar();
        UpdateLevelText();
    }

    void UpdateExpBar()
    {
        float fillAmount = currentExp / maxExp;
        expBarForeground.fillAmount = fillAmount;
    }

    void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel;
    }

    public void AddExp(float exp)
    {
        currentExp += exp;
        if(currentExp >= maxExp)
        {
            LevelUp();
        }
        UpdateExpBar();
    }

    void LevelUp()
    {
        currentLevel++;
        currentExp = 0;
        maxExp *= 1.5f;
        UpdateExpBar();
        UpdateLevelText();
        skillPointManager.AddSkillPoint();
    }

    public void SetMaxExp(float maxExp)
    {
        this.maxExp = maxExp;
        UpdateExpBar();
    }
}
