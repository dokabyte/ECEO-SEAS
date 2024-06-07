using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed = 5f; // Velocidade padr�o do movimento
    private float moveDirection = 1f; // Dire��o padr�o do movimento

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
        // Move o obst�culo para cima ou para baixo com base na dire��o
        transform.Translate(Vector2.up * speed * moveDirection * Time.deltaTime);
    }

    
}
