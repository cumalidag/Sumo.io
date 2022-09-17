using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionDetection : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with the food
        if (other.CompareTag("Player"))
        {
            // Destroy the food
            Destroy(gameObject);
            // Increase the score
            other.GetComponent<Player>().score++;

        }
    }

}
