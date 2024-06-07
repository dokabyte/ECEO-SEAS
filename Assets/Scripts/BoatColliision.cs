using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatColliision : MonoBehaviour
{
    
    private bool isDead;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            PlayerHealth.health--; // Diminui uma vida
            Debug.Log("Hit obstacle! Lives: " + PlayerHealth.health);

            

            if (PlayerHealth.health <= 0 && !isDead)
            {
                isDead = true;
                gameManager.gameOver();
                Destroy(gameObject);
                
            }
        }
    }

    




}
