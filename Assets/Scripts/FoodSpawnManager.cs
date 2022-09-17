using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    public float spawnTime = 1f;
    public float spawnDelay = 1f;

    void Start()
    {
        // Spawn food every spawnTime seconds, starting in spawnDelay seconds
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        // Randomly generate a position for the food to spawn
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 0 , Random.Range(-8f, 8f));
        // Spawn the food
        Instantiate(GameManager.instance.food, spawnPosition, Quaternion.identity);
    }
}
