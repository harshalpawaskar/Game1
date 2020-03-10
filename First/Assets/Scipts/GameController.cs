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

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        location = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
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
}
