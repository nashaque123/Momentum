using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScript : MonoBehaviour {
    private int playerScore;
    private int cpuScore;

    private int finalScore;
    private int questionsAnsweredCorrectly;

    private float timeLeft = 45.0f;
    private float countdown = 3.0f;

    private int randomQuestion = -1;

    private bool gamePlaying = false;
    private bool displayInfo = false;

    private bool gameOverCalled = false;

    GUIStyle style = new GUIStyle();

    // Use this for initialization
    void Start () {
        style.normal.textColor = Color.magenta;
        style.fontSize = 18;
    }
	
	// Update is called once per frame
	void Update () {
        finalScore = playerScore + questionsAnsweredCorrectly - cpuScore;

        if (gamePlaying)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
                timeLeft -= Time.deltaTime;
        }

        if (timeLeft <= 0 && !gameOverCalled)
        {
            ToggleGamePlaying();
            ToggleDisplay();
            SceneManager.LoadScene("GameOverScreen");
            gameOverCalled = true;
        }
	}

    public void IncreasePlayerScore()
    {
        playerScore++;
    }

    public void IncreaseCPUScore()
    {
        cpuScore++;
    }

    public void IncreaseQuestionsAnsweredCorrectly()
    {
        questionsAnsweredCorrectly++;
    }

    public int GetQuestionsAnsweredCorrectly()
    {
        return questionsAnsweredCorrectly;
    }

    public int GetFinalScore()
    {
        return finalScore;
    }

    public float GetCountdown()
    {
        return countdown;
    }

    public void ResetCountdown()
    {
        countdown = 3.0f;
    }

    public int GetRandomQuestion()
    {
        return randomQuestion;
    }

    public void ToggleGamePlaying()
    {
        gamePlaying = !gamePlaying;
    }

    public void ToggleDisplay()
    {
        displayInfo = !displayInfo;
    }

    public void SetChangeQuestion()
    {
        randomQuestion = Random.Range(0, 5);
    }

    public void ResetGame()
    {
        playerScore = 0;
        cpuScore = 0;
        finalScore = 0;
        questionsAnsweredCorrectly = 0;
        timeLeft = 45.0f;
        countdown = 3.0f;
        gamePlaying = false;
        displayInfo = false;
        gameOverCalled = false;
    }

    void OnGUI()
    {
        if (displayInfo)
        {
            if (timeLeft >= 0)
            {
                GUI.Label(new Rect(10, 10, 200, 200), "Player score: " + playerScore, style);
                GUI.Label(new Rect((Screen.width - 160), 10, 200, 200), "Computer score: " + cpuScore, style);
                GUI.Label(new Rect((Screen.width / 2 - 50), 10, 200, 200), "Time left: " + (int)timeLeft, style);
            }
        }
    }
}
