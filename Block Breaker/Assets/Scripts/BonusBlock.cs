using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{

    Paddle paddle;

    void Start()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Ball" || collision.collider.name == "Paddle"){
            Debug.Log("Implement Bonus");
            Destroy(gameObject);
            paddle.ScalePaddle2x();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
