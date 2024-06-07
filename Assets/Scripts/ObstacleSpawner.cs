using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public float spawnDistanceAhead = 10f; // Dist�ncia � frente do barco para spawn
    public float spawnHeight = 5f; // Altura de spawn (para cima e para baixo)
    public float obstacleSpeed = 5f; // Velocidade do obst�culo
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
        // Calcula a posi��o de spawn � frente do barco
        Vector3 spawnPos = transform.position + transform.right * spawnDistanceAhead;

        // Determina se o obst�culo deve se mover para cima ou para baixo com base na posi��o de spawn
        bool spawnAbove = Random.value > 0.5f;
        float posY = spawnAbove ? spawnHeight : -spawnHeight;

        // Adiciona a posi��o de altura ao spawnPos
        spawnPos.y += posY;

        // Escolhe um obst�culo aleat�rio da lista
        GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Count)];

        // Instancia o obst�culo na posi��o calculada
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        // Obt�m o componente de movimento do obst�culo e define a dire��o do movimento
        ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
        if (obstacleMovement != null)
        {
            float moveDirection = spawnAbove ? -1f : 1f; // Se spawnAbove for verdadeiro, mova para baixo, sen�o mova para cima
            obstacleMovement.SetMoveDirection(moveDirection);
            obstacleMovement.SetSpeed(obstacleSpeed);

            // Destruir o obst�culo ap�s 5 segundos
            Destroy(obstacle, 5f);
        }
    }
}
