using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int level;

    public void PlayLevel()
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()//Reseting the TimeScale
    {
        Time.timeScale = 1;
    }

}
