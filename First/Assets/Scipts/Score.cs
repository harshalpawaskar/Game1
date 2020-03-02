using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreChange;

    public void addScore(int score)
    {
        int temp = int.Parse(scoreChange.text);
        int sum = temp + score;
        scoreChange.text = sum.ToString();
    }

    public void subScore(int score)
    {
        int temp = int.Parse(scoreChange.text);
        int sum = temp - score;
        if (sum < 0) sum = 0;
        scoreChange.text = sum.ToString();
    }
}
