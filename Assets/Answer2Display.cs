using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer2Display : MonoBehaviour {
    List<string> answer2 = new List<string>()
    {
        "Contracting",
        "Blocks",
        "6000 Joules",
        "Momentum = mass / velocity",
        "300 million m/s"
    };

    GameObject gameManager;
    GameObject questionDisplay;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        questionDisplay = GameObject.FindWithTag("QuestionDisplay");
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = answer2[gameManager.GetComponent<MasterScript>().GetRandomQuestion()];
    }

    private void OnMouseDown()
    {
        questionDisplay.GetComponent<QuestionDisplay>().selectedAnswer = gameObject.name;
        questionDisplay.GetComponent<QuestionDisplay>().choiceMade = true;
    }
}
