using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Score scoreChange;
    public GameObject resultPanel;
    public WonOrLost wonOrLost;
    public Animator textAnimationAdd;//Add Score Animation
    public Animator textAnimationSub;//Sub Score Animation
    public Text subScoreText;
    public int count = 0;
    Animator animator;
    private bool collided = false;
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
            newRigidbody.AddForce(-2500 * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            newRigidbody.AddForce(2500 * Time.deltaTime, 0, 0);
    }

    [Obsolete]
    void Update()
    {
        if(collided)
        {
            animator.Play("Collide");
            StartCoroutine(Coroutine1());
            collided = false;
        }

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
                    textAnimationAdd.Play("TextAnimation");
                    scoreChange.addScore(100);
                    firstStrike = true;
                }
        }
        else if (Physics.Raycast(ray2, out hit, 15))
        {
            if (hit.collider.tag == "Obstacle")
                if (!firstStrike)
                {
                    textAnimationAdd.Play("TextAnimation");
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
            collided = true; 
            obstacleNo = int.Parse(collision.gameObject.name);
            newRigidbody.AddForce(0, 0, -moveSpeed * (1.0f + newRigidbody.velocity.z / 20) * Time.deltaTime, ForceMode.Impulse);
            count++;
            scoreChange.subScore(count * obstacleNo * 10);
            subScoreText.text = "-" + (count * obstacleNo * 10).ToString();
            //animator.Play("Collide");
            if (PlayerPrefs.GetString("Vibrate") == "true")
                Handheld.Vibrate();
        }
    }

    IEnumerator Coroutine1()
    {
        //Debug.Log("Start");
        yield return new WaitForSeconds(0.5f);
        textAnimationSub.Play("TextAnimation1");
        //Debug.Log("Stop");
    }
}