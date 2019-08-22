using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int unbrokenBlocks;

    SceneLoad sceneLoader;

    public void Start(){
        sceneLoader = FindObjectOfType<SceneLoad>();
    }
    public void countBreakableBlocks(){
        unbrokenBlocks ++;
    }

    public void BlockDestroyed(){
        unbrokenBlocks -- ;
        if (unbrokenBlocks <= 0){
            sceneLoader.loadNextScene();
        }
    }
}