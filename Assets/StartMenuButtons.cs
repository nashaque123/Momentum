using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour {

    private void OnMouseDown()
    {
        if (gameObject.name == "StartGameButton")
        {
            SceneManager.LoadScene("Main");
            GameObject.FindWithTag("GameManager").GetComponent<MasterScript>().ToggleDisplay();
            GameObject.FindWithTag("GameManager").GetComponent<MasterScript>().ToggleGamePlaying();
        }
        else if (gameObject.name == "EndGameButton")
            Application.Quit();
    }
}
