using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    NavMeshAgent agent;
    AiStates currentState;
    public GameObject enemies;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        currentState = new PatrolForFood (enemies, agent, GameManager.instance.food, GameManager.instance.tempPlayer);
    }


    void Update()
    {

        currentState = currentState.Process();
    }
}
