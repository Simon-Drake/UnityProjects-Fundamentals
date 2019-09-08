using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{

    // Cached references
    Paddle paddle;
    Renderer render;
    BoxCollider2D colidr;
    Rigidbody2D rigidBody;

    // At initialisation
    void Start()
    {
        Deactivate();
        StartCoroutine(Wait());
        paddle = FindObjectOfType<Paddle>();
    }

    // Deactivate relevant components
    private void Deactivate()
    {
        render = GetComponent<Renderer>();
        render.enabled = false;
        colidr = GetComponent<BoxCollider2D>();
        colidr.enabled = false;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;
    }

    // Implement delay
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Activate();
    }
    
    // Activate object
    public void Activate()
    {
        render.enabled = true;
        colidr.enabled = true;
        rigidBody.isKinematic = false;
    }

    // Collision handler 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Ball" || collision.collider.name == "Paddle"){
            Debug.Log("Implement Bonus");
            paddle.ScalePaddle2x();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
