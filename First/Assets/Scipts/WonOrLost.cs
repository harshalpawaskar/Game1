using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WonOrLost: MonoBehaviour
{
    public GameObject player;

    public int highScoreNo;

    public Text resultText;

    public Text score;

    public Text totalScore;

    public Text highScore;

    public GameObject failedResultButtons;

    public GameObject passedResultButtons;

    public void ShowResult(bool result)
    {
        totalScore.text = score.text;
        if (result)
        {
            resultText.text = "RESPECT + +";
            if (int.Parse(highScore.text) < int.Parse(totalScore.text))
                highScore.text = totalScore.text;
            highScoreNo = int.Parse(highScore.text);
            passedResultButtons.SetActive(true);
        }
        else
        {
            resultText.text = "RESPECT - -";
            failedResultButtons.SetActive(true);
        }
    }

    public int ReturnHighScore()
    {
        return highScoreNo;
    }
}
