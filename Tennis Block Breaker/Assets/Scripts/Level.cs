using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Member variables
    [SerializeField] int unbrokenBlocks;

    // Class instances
    SceneLoad sceneLoader;

    public void Start()
    {
        // Get scene loader to load next level
        sceneLoader = FindObjectOfType<SceneLoad>();
    }

    // Updates number of unbroken blocks when a block is created.
    public void countBreakableBlocks(){
        unbrokenBlocks ++;
    }

    // Update number of broken blocks and load next scene if = 0;
    public void BlockDestroyed(){
        unbrokenBlocks -- ;
        if (unbrokenBlocks <= 0){
            sceneLoader.loadNextScene();
        }
    }
}