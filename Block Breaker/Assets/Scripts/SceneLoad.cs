using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class that deals with loading scenes
public class SceneLoad : MonoBehaviour
{
    // Load next scene in hierarchy
    public void loadNextScene()
    {

        // Get scene index and load next one.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1 );
    }

    // Start button onClick()
    public void loadStartScene(){
        FindObjectOfType<GameState>().DestroyGameState();
        SceneManager.LoadScene(0);
    }

    // Quit button onClick()
    public void quitGame(){
        Application.Quit();
    }
}
