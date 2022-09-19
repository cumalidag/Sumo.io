using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // Enemy spawn range
    public float spawnRange = 9;
    // Enemy spawn count
    public int enemyCount = 7;

    
    void Start()
    {
        // Spawn enemies
        SpawnEnemyWave(enemyCount);
    }
    // This method will be used to spawn enemies
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(GameManager.instance.enemy, GenerateSpawnPosition(), Quaternion.identity);
        }
    }
    // This method will be used to generate a random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
