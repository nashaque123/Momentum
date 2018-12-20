using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	//Creating variable for speed of paddle
	private float speed = 4.5f;

    //Variable to limit height of paddle
    private float boundY = 3.35f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		//If statement to change velocity of paddle based on key pressed
		if (Input.GetKey(KeyCode.UpArrow))
            rb2d.velocity = Vector2.up * speed;
		else if (Input.GetKey(KeyCode.DownArrow))
            rb2d.velocity = Vector2.down * speed;
		else 
            rb2d.velocity = Vector2.zero;

        //Change position of paddle based on velocity but keep it within bounds
        var pos = transform.position;

        if (pos.y > boundY)
            pos.y = boundY;
        else if (pos.y < -boundY)
            pos.y = -boundY;

        transform.position = pos;
    }
}
