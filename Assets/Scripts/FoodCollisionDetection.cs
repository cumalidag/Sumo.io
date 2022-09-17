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
            other.GetComponent<Player>().transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        }
    }

}
