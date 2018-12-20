using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer1Display : MonoBehaviour {
    List<string> answer1 = new List<string>()
    {
        "Constant",
        "Particles",
        "6000 kWh",
        "Momentum = mass * velocity",
        "300 thousand m/s"
    };

    GameObject gameManager;
    GameObject questionDisplay;

    // Use this for initialization
    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
        questionDisplay = GameObject.FindWithTag("QuestionDisplay");
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = answer1[gameManager.GetComponent<MasterScript>().GetRandomQuestion()];
    }

    private void OnMouseDown()
    {
        questionDisplay.GetComponent<QuestionDisplay>().selectedAnswer = gameObject.name;
        questionDisplay.GetComponent<QuestionDisplay>().choiceMade = true;
    }
}
