using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Configuration
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 1;

    // State variables
    [SerializeField] int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set speed
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
}
