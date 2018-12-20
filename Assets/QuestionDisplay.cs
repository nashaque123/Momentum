using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionDisplay : MonoBehaviour {
    List<string> questions = new List<string>()
    {
        "When scientists look at the universe, they see it is...",
        "What are all materials are made of?",
        "A 600W computer used for 10 hours uses how much energy?",
        "What is the equation for momentum?",
        "In a vacuum, what speed do waves travel at?"
    };

    List<string> correctAnswers = new List<string>()
    {
        "Answer3",
        "Answer1",
        "Answer3",
        "Answer1",
        "Answer2"
    };

    public string selectedAnswer;
    public bool choiceMade = false;

    GameObject gameManager;
    private int randomQuestion;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindWithTag("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
        randomQuestion = gameManager.GetComponent<MasterScript>().GetRandomQuestion();
        GetComponent<TextMesh>().text = questions[randomQuestion];

        if (choiceMade)
        {
            if (correctAnswers[randomQuestion] == selectedAnswer)
            {
                gameManager.GetComponent<MasterScript>().IncreaseQuestionsAnsweredCorrectly();
            }

            SceneManager.LoadScene("Main");
            choiceMade = false;
            gameManager.GetComponent<MasterScript>().ToggleGamePlaying();
        }
	}
}
