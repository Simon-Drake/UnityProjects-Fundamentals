using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{
    [SerializeField] Paddle paddle;
    [SerializeField] float releaseVectorX = 2f;
    [SerializeField] float releaseVectorY = 14f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBall;

    //Cached component references
    AudioSource myAudioSource;

    bool hasStarted = false;

    // Start is called before the first frame update
    void Start(){
        myAudioSource = GetComponent<AudioSource>();
        paddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the game hasn't started lock ball to paddle. 
        if(!hasStarted){
            LockToPaddle();
            LaunchOnClick();
        }
    }

    // If clicks gam starts
    private void LaunchOnClick(){
        if (Input.GetMouseButtonDown(0))
        {
            // Initialise velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(releaseVectorX, releaseVectorY);
            hasStarted = true;
        }
    }

    // Locks ball to paddle
    void LockToPaddle(){
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    // Play random sound if ball hits something.
    private void OnCollisionEnter2D(Collision2D collision){
        if (hasStarted){
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
        