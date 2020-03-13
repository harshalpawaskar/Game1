using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for touch input

public class Move : MonoBehaviour
{
    private Rigidbody newRigidbody; 
    public GameObject player;
    private float screenWidth;
    void Start()
    {
        screenWidth = Screen.width;
        newRigidbody = player.GetComponent<Rigidbody>();
    }
    /*
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x > screenWidth / 2)
                        //player.transform.Translate(Vector3.right * 50 * Time.deltaTime);
                        newRigidbody.AddForce(new Vector3(1500 * Time.deltaTime, 0, 0));
                    if (touch.position.x < screenWidth / 2)
                        //player.transform.Translate(Vector3.left * 50 * Time.deltaTime); 
                        newRigidbody.AddForce(new Vector3(-1500 * Time.deltaTime, 0, 0));
                    break;
                case TouchPhase.Stationary:
                    if (touch.position.x > screenWidth / 2)
                        //player.transform.Translate(Vector3.right * 50 * Time.deltaTime); 
                        newRigidbody.AddForce(new Vector3(1500 * Time.deltaTime, 0, 0));
                    if (touch.position.x < screenWidth / 2)
                        //player.transform.Translate(Vector3.left * 50 * Time.deltaTime); 
                        newRigidbody.AddForce(new Vector3(-1500 * Time.deltaTime, 0, 0));
                    break;
                case TouchPhase.Ended:
                    newRigidbody.x
                    break;
            }
        }
    }*/

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > screenWidth / 2)
                newRigidbody.AddForce(2500 * Time.deltaTime, 0, 0);
            if (Input.GetTouch(0).position.x < screenWidth / 2)
                newRigidbody.AddForce(-2500 * Time.deltaTime, 0, 0);
        }
    }
}
