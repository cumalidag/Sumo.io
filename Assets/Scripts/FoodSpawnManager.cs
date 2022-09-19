using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    [SerializeField] FoodCollisionDetection foodCollisionDetectionScript;
    
    private void Start()
    {
        Spawn();
    }
    
    private void Update()
    {

        if (GameManager.instance.food.Count < 8)
        {
            // Spawn food every spawnTime seconds, starting in spawnDelay seconds
            SpawnDeleted(foodCollisionDetectionScript.IndexOfDeletedFood);
        }

    }   
    void Spawn() {
        for (int i = 0; i < 8; i++)
        {
            // Randomly generate a position for the food to spawn
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
            // Spawn the food
            GameManager.instance.food.Add(Instantiate(GameManager.instance.foodPrefabs, spawnPosition, GameManager.instance.foodPrefabs.transform.rotation));
            
        }
        
    }
    
    void SpawnDeleted(int deletedFoodIndex)
    {
        {
            // Randomly generate a position for the food to spawn
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
            // Spawn the food
            GameManager.instance.food.Insert(deletedFoodIndex,Instantiate(GameManager.instance.foodPrefabs, spawnPosition, GameManager.instance.foodPrefabs.transform.rotation));
        }
    }
    
}
