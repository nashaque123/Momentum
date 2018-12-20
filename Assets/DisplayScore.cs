using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {
    GameObject gameManager;
    GUIStyle style = new GUIStyle();
    private int questionsAnsweredCorrectly;
    private int finalScore;
       
    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindWithTag("GameManager");
        style.fontSize = 25;
        style.normal.textColor = Color.white;
        questionsAnsweredCorrectly = gameManager.GetComponent<MasterScript>().GetQuestionsAnsweredCorrectly();
        finalScore = gameManager.GetComponent<MasterScript>().GetFinalScore();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(250, 40, 200, 200), "Time's up!", style);
        GUI.Label(new Rect(250, 65, 200, 200), "You answered " + questionsAnsweredCorrectly + " questions correctly!", style);
        GUI.Label(new Rect(250, 90, 200, 200), "Your final score was " + finalScore, style);
    }
}
