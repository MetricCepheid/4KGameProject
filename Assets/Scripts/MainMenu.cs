using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        EditorApplication.Exit(0);
        Application.Quit();
    }
}
