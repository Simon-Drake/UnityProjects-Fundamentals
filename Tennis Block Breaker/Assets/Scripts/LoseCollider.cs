using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // Ball drop on floor trigger. Game over
    private void OnTriggerEnter2D(Collider2D collision){
        SceneManager.LoadScene("Game Over");
    }
}
