using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject moveButtons;
    public GameObject pause;
    public GameObject PressEnterPanel;
    public PlayerMovement player;
    public Transform location;
    public WonOrLost wonOrLost;
    public GameObject resultPanel;
    public Text highScore;
    public int endLine;
    public GameObject[] obstacles;
    public float[] zPositions;
    private int[] randomNoArray = new int[15];
    private int[] tempArray = new int[15];

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        location = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        Debug.Log("Game Started!!!");
        if (SceneManager.GetActiveScene().buildIndex == 5)
            RearrangeObstacles();
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!PressEnterPanel.activeSelf)//Activating the pause menu
            {
                Time.timeScale = 0;
                pause.SetActive(true);
                moveButtons.SetActive(false);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            player.enabled = true;
            GameObject gameObject = GameObject.FindGameObjectWithTag("PressEnterPanel");
            gameObject.SetActive(false); 
        }*/
        if (player.count == 3)//Ending the game on player.count=3
        {
            resultPanel.SetActive(true);
            if (location.position.z < endLine)
            {
                wonOrLost.ShowResult(false);
            }
            moveButtons.SetActive(false);
            Time.timeScale = 0;
        }
        if (location.position.z >= endLine)
        {
            Time.timeScale = 0;
            resultPanel.SetActive(true);
            wonOrLost.ShowResult(true);
            moveButtons.SetActive(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void RearrangeObstacles()
    {
        GenerateRandomArray();
        for (int i = 0; i < 15; i++)
        {
            Vector3 tempPos = obstacles[i].transform.position;
            float pos = zPositions[randomNoArray[i]];
            tempPos.z = pos;
            obstacles[i].transform.position = tempPos;
        }
    }

    public void GenerateRandomArray()
    {
        System.Random random = new System.Random();
        int count = 15;
        int max = 15;
        for (int i = 0; i < 15; i++)
            tempArray[i] = i;
        for (int i = 0; i < max; i++)
        {
            int j = random.Next(0, count - 1);
            randomNoArray[i] = tempArray[j];
            for (int k = j; k < count - 1; k++)
                tempArray[k] = tempArray[k + 1];
            count--;
        }
    }
}
