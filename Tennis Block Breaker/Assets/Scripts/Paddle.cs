using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour{

    // Configuration variavles
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX;
    [SerializeField] float maxX;




    // Start is called before the first frame update
    void Start()
    {
        // Set boundaries
        minX = 1f;
        maxX = 15f;
    }

    // Update is called once per frame
    void Update(){

        // Clamp paddle movement and update position
        float mouseXPos = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos  = new Vector2(Mathf.Clamp(mouseXPos, minX, maxX), 0);
        transform.position = paddlePos;
    }
}
