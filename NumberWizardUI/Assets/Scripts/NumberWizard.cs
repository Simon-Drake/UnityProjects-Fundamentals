using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{

    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame(){
        updateGuess();
    }

    public void onPressHigher(){
        min = guess + 1;
        updateGuess();
    }

    public void onPressLower(){
        max = guess - 1;
        updateGuess();
    }

    void updateGuess(){
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();

    }
}
