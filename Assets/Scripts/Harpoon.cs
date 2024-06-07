using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lixo"))
        { 
            Destroy(other.gameObject); // Destroi o lixo
            Destroy(gameObject); // Destroi o arpão
        }
    }
}
