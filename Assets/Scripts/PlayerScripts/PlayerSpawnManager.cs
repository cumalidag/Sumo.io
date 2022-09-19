using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    // This is float variable that will be used to spawn the player
    public float spawnRange = 9;
    void Start()
    {
        // Spawn player at random position
        GameManager.instance.tempPlayer = Instantiate(GameManager.instance.player, GenerateSpawnPosition(), Quaternion.identity);
    }

    // This method will be used to generate a random position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }


}
