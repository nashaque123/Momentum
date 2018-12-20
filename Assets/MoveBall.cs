using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    private float speed = 5.0f;
    GameObject gameManager;
    private bool resetBall = true;
    private int randDirection;

    float countdown;

    GUIStyle style = new GUIStyle();

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        style.fontSize = 30;
        style.normal.textColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        countdown = gameManager.GetComponent<MasterScript>().GetCountdown();

        if (resetBall)
        {
            if (countdown <= 0)
            {
                StartBall();
                resetBall = false;
            }
        }
    }

    void StartBall()
    { 
        randDirection = Random.Range(0, 3);

        if (randDirection == 1)
            GetComponent<Rigidbody2D>().velocity = Vector2.one * -speed;
        else
            GetComponent<Rigidbody2D>().velocity = Vector2.one * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GoalScored")
        {
            gameManager.GetComponent<MasterScript>().IncreasePlayerScore();
            gameManager.GetComponent<MasterScript>().SetChangeQuestion();
            gameManager.GetComponent<MasterScript>().ToggleGamePlaying();
            SceneManager.LoadScene("QuestionsScene");
            ResetBall();     
        }

        else if (collision.gameObject.tag == "GoalConceded")
        {
            gameManager.GetComponent<MasterScript>().IncreaseCPUScore();
            gameManager.GetComponent<MasterScript>().SetChangeQuestion();
            gameManager.GetComponent<MasterScript>().ToggleGamePlaying();
            SceneManager.LoadScene("QuestionsScene");
            ResetBall();
        }
    }

    void ResetBall()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = new Vector2(0f, 0.05f);
        gameManager.GetComponent<MasterScript>().ResetCountdown();
        resetBall = true;
    }


    void OnGUI()
    {
        if (countdown >= 0)
            GUI.Label(new Rect((Screen.width / 2), (Screen.height / 2), 200, 200), " " + ((int)countdown + 1), style);
    }
}