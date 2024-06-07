using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> obstacles; 
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime = 1.2f;
    public float spawnRadius = 5f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {

        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0f);

        // Escolhe um obstáculo aleatório da lista
        GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Count)];

        // Instancia o obstáculo na posição aleatória
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
