﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Score scoreChange;
    public GameObject resultPanel;
    public WonOrLost wonOrLost;
    public int count = 0;
    Animator animator;
    private Rigidbody newRigidbody; 
    private bool firstStrike = false;
    private int obstacleNo;

    private void Awake()
    {

    }

    void Start()
    {
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        newRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        newRigidbody.AddForce(0, 0, moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            newRigidbody.AddForce(-2750 * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            newRigidbody.AddForce(2750 * Time.deltaTime, 0, 0);
    }

    [Obsolete]
    void Update()
    {
        FallFunction();

        //Checking if player has passed the obstacle or not
        #region Raycasting
        RaycastHit hit;
        Ray ray1 = new Ray(transform.position, Vector3.right);
        Ray ray2 = new Ray(transform.position, Vector3.left);

        if (Physics.Raycast(ray1, out hit, 15))
        {
            if (hit.collider.tag == "Obstacle")
                if (!firstStrike)
                {
                    scoreChange.addScore(100);
                    firstStrike = true;
                }
        }
        else if (Physics.Raycast(ray2, out hit, 15))
        {
            if (hit.collider.tag == "Obstacle")
                if (!firstStrike)
                {
                    scoreChange.addScore(100);
                    firstStrike = true;
                }
        }
        else firstStrike = false;
        #endregion
    }

    //Checking if Player is on the ground or not,if player falls then restarting the game
    [Obsolete]
    void FallFunction()
    {
        if (gameObject.transform.position.y <= -5)
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }

    //Checking Collision With Obstacles
    [Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            obstacleNo = int.Parse(collision.gameObject.name);
            newRigidbody.AddForce(0, 0, -moveSpeed * (1.0f + newRigidbody.velocity.z / 20) * Time.deltaTime, ForceMode.Impulse);
            count++;
            scoreChange.subScore(count * obstacleNo * 10);
            animator.SetTrigger("Trigger1");
        }
    }
}