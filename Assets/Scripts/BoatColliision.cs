using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatColliision : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    private bool isDead;
    public GameManager gameManager;
    public AudioClip hitSound;
    private AudioSource audioSource2;

    private void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
        if (audioSource2 == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Please add an AudioSource component.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            playerHealth.health--;
            playerHealth.UpdateHealth();
            Debug.Log("Hit obstacle! Lives: " + playerHealth.health);

            if (audioSource2 != null && hitSound != null)
            {
                audioSource2.PlayOneShot(hitSound);
            }
            else
            {
                Debug.LogError("Missing AudioSource or Shoot Sound. Please assign both in the Inspector.");
            }



            if (playerHealth.health <= 0 && !isDead)
            {
                isDead = true;
                gameManager.gameOver();
                Time.timeScale = 0f;
                Destroy(gameObject);
                
                
            }
        }
    }

    




}
