using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
