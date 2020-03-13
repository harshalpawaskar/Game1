using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WonOrLost: MonoBehaviour
{
    public GameObject player;
    public Text resultText;
    public Text score;
    public Text totalScore;
    public Text highScore;
    public GameObject failedResultButtons;
    public GameObject passedResultButtons;

    public void ShowResult(bool result)
    {
        int level=SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetFloat("Level" + level.ToString(), int.Parse(highScore.text));
        totalScore.text = score.text;
        if (result)
        {
            resultText.text = "RESPECT + +";
            resultText.color = Color.green;
            if (int.Parse(highScore.text) <= int.Parse(totalScore.text))
            {
                highScore.text = totalScore.text;
                PlayerPrefs.SetFloat("Level" + level.ToString(), int.Parse(highScore.text));
            }
            passedResultButtons.SetActive(true);
        }
        else
        {
            resultText.text = "RESPECT - -";
            resultText.color = Color.red;
            failedResultButtons.SetActive(true);
        }
    }

    [System.Obsolete]
    public void RetryLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
