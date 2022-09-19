using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodCollisionDetection : MonoBehaviour
{
    int indexOfDeletedFood = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public int IndexOfDeletedFood
    {
        get { return indexOfDeletedFood; }
        set { indexOfDeletedFood = value; }
    }
    private void OnTriggerEnter(Collider other)
    {


        // If the player collides with the food
        if (other.CompareTag("Player"))
        {
            // Destroy the food
            indexOfDeletedFood = GameManager.instance.food.IndexOf(gameObject);
            Destroy(gameObject);
            GameManager.instance.food.RemoveAt(indexOfDeletedFood);
            // Increase the score
            other.GetComponent<Player>().score++;
            other.GetComponent<Player>().transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            other.GetComponent<Player>().transform.position += new Vector3(0, 0.1f, 0);
            other.GetComponent<Player>().impulse += 100;
            GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>().text = "Score: " + other.GetComponent<Player>().score;

        }
        
        if (other.CompareTag("Enemy"))
        {
            // Destroy the food

            indexOfDeletedFood = GameManager.instance.food.IndexOf(gameObject);
            Destroy(gameObject);
            GameManager.instance.food.RemoveAt(indexOfDeletedFood);
            // Increase the score
            other.GetComponent<Player>().score++;
            other.GetComponent<Player>().transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            other.GetComponent<Player>().transform.position += new Vector3(0, 0.1f, 0);
            other.GetComponent<Player>().impulse += 100;

        }

    }

}
