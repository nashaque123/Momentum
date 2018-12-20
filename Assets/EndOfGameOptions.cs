using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameOptions : MonoBehaviour {	

    private void OnMouseDown()
    {
        if (gameObject.tag == "BackToMenu")
        {
            GameObject.FindWithTag("GameManager").GetComponent<MasterScript>().ResetGame();
            SceneManager.LoadScene("StartScene");
        }
    }
}
