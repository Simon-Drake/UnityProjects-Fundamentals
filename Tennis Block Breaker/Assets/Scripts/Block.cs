using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    // Configuration
    [SerializeField] AudioClip breakSound;

    // State variables
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
        // Play sound and update level member variables
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
