using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    public void UpdateWaveNumber(int waveNumber)
    {
        if(waveText != null)
        {
            waveText.text = "Wave: " + waveNumber;
        }
        else
        {
            Debug.LogError("WaveText is not assigned in the UIManager script");
        }
    }

    public void updateTimer(float timeRemaining)
    {
        if(timerText != null)
        {
            timerText.text = "Next wave in: " + timeRemaining.ToString("F1") + "s";
        }
        else
        {
            Debug.LogError("TimerText is not assigned in the UIManager");
        }
    }
}
