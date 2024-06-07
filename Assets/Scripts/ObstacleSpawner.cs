using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public float spawnDistanceAhead = 10f; // Distância à frente do barco para spawn
    public float spawnHeight = 5f; // Altura de spawn (para cima e para baixo)
    public float obstacleSpeed = 5f; // Velocidade do obstáculo
    public float timeBetweenSpawn = 3f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        // Calcula a posição de spawn à frente do barco
        Vector3 spawnPos = transform.position + transform.right * spawnDistanceAhead;

        // Determina se o obstáculo deve se mover para cima ou para baixo com base na posição de spawn
        bool spawnAbove = Random.value > 0.5f;
        float posY = spawnAbove ? spawnHeight : -spawnHeight;

        // Adiciona a posição de altura ao spawnPos
        spawnPos.y += posY;

        // Escolhe um obstáculo aleatório da lista
        GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Count)];

        // Instancia o obstáculo na posição calculada
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        // Obtém o componente de movimento do obstáculo e define a direção do movimento
        ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
        if (obstacleMovement != null)
        {
            float moveDirection = spawnAbove ? -1f : 1f; // Se spawnAbove for verdadeiro, mova para baixo, senão mova para cima
            obstacleMovement.SetMoveDirection(moveDirection);
            obstacleMovement.SetSpeed(obstacleSpeed);

            // Destruir o obstáculo após 5 segundos
            Destroy(obstacle, 5f);
        }
    }
}
