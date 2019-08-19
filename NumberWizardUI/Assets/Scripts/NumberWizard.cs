using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{

    int min;

    int test;
    int max;
    int guess;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame(){
        max = 1000;
        min = 1;
        guess = 500;
        Debug.Log("Welcome to number wizard.");
        Debug.Log("Pick a number");
        Debug.Log("Highest:  " + max);
        Debug.Log("Lowest: " + min);
        Debug.Log("Our guess is: " + guess);
        Debug.Log("If higher = up, lower = down, correct = enter");
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            print("upkey");
            min = guess;
            updateGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            print("downkey");
            max = guess;
            updateGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return)){
            print("You win!");
            StartGame();
        }
    }

    void updateGuess(){
        guess = (min+max)/2;
        Debug.Log("Is it higher or lower than " + guess + "?");   
    }
}
