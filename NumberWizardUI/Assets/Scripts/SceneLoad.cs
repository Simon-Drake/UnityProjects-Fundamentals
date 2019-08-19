using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    public void loadNextScene(){

        // Get scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1 );
    }

    public void loadStartScene(){
        SceneManager.LoadScene(0);
    }
}
