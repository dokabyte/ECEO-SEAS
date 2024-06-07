using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed = 5f; // Velocidade padrão do movimento
    private float moveDirection = 1f; // Direção padrão do movimento

    public void SetMoveDirection(float direction)
    {
        moveDirection = direction;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        // Move o obstáculo para cima ou para baixo com base na direção
        transform.Translate(Vector2.up * speed * moveDirection * Time.deltaTime);
    }

    
}
