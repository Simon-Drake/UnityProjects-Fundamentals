using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    // Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached references
    Level level;

    // State variables 
    [SerializeField] int timesHit; //(serialised for debug)

    public void Start()
    {
        if(tag == "Breakable")
        {
            // Called on every creation of a Block instance
            // Sums unbroken blocks
            level = FindObjectOfType<Level>();
            level.countBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if(timesHit >= maxHits){
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
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    // Update sprite to display breakage.
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("bad index" + gameObject.name);
        }
    }

    // Instantiates particle effect prefab
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
