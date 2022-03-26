using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float enemyHeightSpawn;
    public float spawnTime;
    public int numberOfEnemiesToBeSpawned = 2;

    private void Start()
    {
        InvokeRepeating("SpawnRandomEnemies", spawnTime, spawnTime);
    }

    private void SpawnRandomEnemies()
    {
        UnityEngine.Debug.Log("Number of enemies: " + numberOfEnemiesToBeSpawned);
        for (int i = 0; i < numberOfEnemiesToBeSpawned; i++)
        {
            Vector3 spawnPosition = getEnemySpawnRandomPosition();
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private UnityEngine.Vector3 getEnemySpawnRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-5f, 5f), enemyHeightSpawn, 0);
    }
}
