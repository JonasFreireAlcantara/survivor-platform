// using System.Numerics;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float enemyHeightSpawn;
    public float spawnTime;

    private void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", spawnTime, spawnTime);
    }

    private void SpawnRandomEnemy()
    {
        Vector3 spawnPosition = getEnemySpawnRandomPosition();
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

    private UnityEngine.Vector3 getEnemySpawnRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-5f, 5f), enemyHeightSpawn, 0);
    }
}
