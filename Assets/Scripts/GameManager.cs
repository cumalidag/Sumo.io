using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This particular class controls Game
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // This is a variable that will be used to store the player
    public GameObject player;
    public GameObject tempPlayer;
    // This is a variable that will be used to store the enemy
    public GameObject enemy;
    // This is a variable that will be used to store the food prefabs
    public GameObject foodPrefabs;
    public List<GameObject> food;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

}




