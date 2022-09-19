using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // This is a variable that will be used to store the player's position
    NavMeshAgent agent;
    // This is the nearest food object
    public GameObject nearestFood = null;
    private void Update()
    {
        GetClosestFood(GameManager.instance.food);
        
        agent = GetComponent<NavMeshAgent>();
        // This will make the enemy move the nearest food
        if (nearestFood != null)
        {
            agent.SetDestination(nearestFood.transform.position);
        }
        

    }
    // This function will find the nearest food object
    GameObject GetClosestFood(List<GameObject> food)
    {
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in food)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                nearestFood = t;
                minDist = dist;
            }
        }
        return nearestFood;
    }


}
