using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public GameObject pause;

    public GameObject PressEnterPanel;

    public PlayerMovement player;

    public Transform location;

    public List<int> highScores = new List<int>();

    public WonOrLost wonOrLost;

    public GameObject resultPanel;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        location = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!PressEnterPanel.activeSelf)
            {
                Time.timeScale = 0;
                pause.SetActive(true);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            player.enabled = true;
            GameObject gameObject = GameObject.FindGameObjectWithTag("PressEnterPanel");
            gameObject.SetActive(false); 
        }*/
        if (player.count == 3)
        {
            resultPanel.SetActive(true);
            if (location.position.z < 425)
            {
                wonOrLost.ShowResult(false);
            }
            Time.timeScale = 0;
        }
        if (location.position.z >= 425)
        {
            Time.timeScale = 0;
            resultPanel.SetActive(true);
            wonOrLost.ShowResult(true);
            int i = SceneManager.GetActiveScene().buildIndex;
            highScores[i] = wonOrLost.ReturnHighScore();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
