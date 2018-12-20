using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCPU : MonoBehaviour {
    //Creating variable for speed of paddle
    private float speed = 3.0f;

    //Variable to limit height of paddle
    private float boundY = 3.35f;

    //Variables to move the paddle
    private Rigidbody2D rb2d;
    private Transform cpuTransform;
    private Transform ballTransform;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ballTransform = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        cpuTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update () {

        //Move the paddle position according to ball position when it's in the cpu's half
        if (cpuTransform.position.y < ballTransform.position.y && ballTransform.position.x >= 0)
            rb2d.velocity = Vector2.up * speed;
        else if (cpuTransform.position.y > ballTransform.position.y && ballTransform.position.x >= 0)
            rb2d.velocity = Vector2.down * speed;
        else
            rb2d.velocity = Vector2.zero;

        var pos = transform.position;
        if (pos.y > boundY)
            pos.y = boundY;
        else if (pos.y < -boundY)
            pos.y = -boundY;

        transform.position = pos;
    }
}
