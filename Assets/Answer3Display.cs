using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer3Display : MonoBehaviour {
    List<string> answer3 = new List<string>()
    {
        "Expanding",
        "Beads",
        "6 kWh",
        "Momentum = mass * velocity / force",
        "3000 million m/s"
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
        GetComponent<TextMesh>().text = answer3[gameManager.GetComponent<MasterScript>().GetRandomQuestion()];
    }

    private void OnMouseDown()
    {
        questionDisplay.GetComponent<QuestionDisplay>().selectedAnswer = gameObject.name;
        questionDisplay.GetComponent<QuestionDisplay>().choiceMade = true;
    }
}
