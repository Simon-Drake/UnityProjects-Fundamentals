using UnityEngine;

public class Ball : MonoBehaviour{

    // Configuration 
    [SerializeField] float releaseVectorX = 2f;
    [SerializeField] float releaseVectorY = 14f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] Paddle paddle;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleToBall;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    bool hasStarted = false;

    // Start is called before the first frame update
    void Start(){
        myAudioSource = GetComponent<AudioSource>();
        paddleToBall = transform.position - paddle.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            myRigidBody2D.velocity = new Vector2(releaseVectorX, releaseVectorY);
            hasStarted = true;
        }
    }

    // Locks ball to paddle
    void LockToPaddle(){
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    // Play random sound if ball hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), 
                                    Random.Range(0f, randomFactor));
        if (hasStarted){
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
        