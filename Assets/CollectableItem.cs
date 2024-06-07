using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public int pointsToAdd = 10; // Pontos a serem adicionados ao coletar este objeto

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Harpoon"))
        {
            GameManager.Instance.AddScore(pointsToAdd); // Usando a referência estática para o GameManager
            Destroy(gameObject);
        }
    }
}
