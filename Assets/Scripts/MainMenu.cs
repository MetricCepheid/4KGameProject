using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void VideoTest()
    {
        SceneManager.LoadScene("Video");
    }

    public void RetryButton()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
