using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureScript : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.getStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        manageStates();
    }

    private void manageStates()
    {
        var nextStates = state.getNextStates();
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            state = nextStates[0];
            textComponent.text = state.getStateStory();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            state = nextStates[1];
            textComponent.text = state.getStateStory();
        }
    }
}
