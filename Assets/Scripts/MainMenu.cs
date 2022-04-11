using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SharpConfig;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public Toggle m_Toggle;
    public Toggle v_Toggle;
    public GameObject config;
    
    public void Start()
    {
        var config = Configuration.LoadFromFile("config.cfg");
        var section = config["Fullscreen"];
        var section1 = config["VSYNC"];

        QualitySettings.vSyncCount = 1;

        Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");

        if(m_Toggle.isOn = !section["Windowed"].BoolValue)
        {
            Screen.SetResolution(Screen.width, Screen.height, true);
        } else
        {
            Screen.SetResolution(1280, 720, false);
        }

        if(v_Toggle.isOn = section1["FPS LOCKED"].BoolValue)
        {
            Application.targetFrameRate = 300;
        } else
        {
            QualitySettings.vSyncCount = 1;
        }
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
