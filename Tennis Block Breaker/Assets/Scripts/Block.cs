using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    // Reference variables
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    Level level;

    public void Start()
    {
        // Called on every creation of a Block instance
        // Sums unbroken blocks
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Add point to player score. 
        FindObjectOfType<GameState>().AddToScore();
        
        // Play sound
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        // Destroy
        Destroy(gameObject);
        level.BlockDestroyed();

        // Create particle effect
        TriggerSparkles();

    }

    // Instantiates particle effect prefab
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
