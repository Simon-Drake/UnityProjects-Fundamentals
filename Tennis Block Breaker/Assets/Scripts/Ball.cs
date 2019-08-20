using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{
    [SerializeField] Paddle paddle;

    Vector2 paddleToBall;

    bool hadStarted = false;

    // Start is called before the first frame update
    void Start(){
        paddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame

    void Update(){
        if(!hadStarted){
            LockToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            hadStarted = true;
        }
    }

    void LockToPaddle(){
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }
}
        