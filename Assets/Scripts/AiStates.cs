using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static AiStates;

public class AiStates
{
    public enum STATE
    {
        PATROLFORFOOD,
        PURSUEFORFOOD,
        PATROLFORPLAYER,
        PURSUEFORPLAYER
    };

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected List<GameObject> food;
    protected AiStates nextState;
    protected NavMeshAgent agent;
    protected GameObject player;

    [SerializeField] private float _visDist = 10.0f;
    [SerializeField] private float _visAngle = 30.0f;
    [SerializeField] private float _eatDist = 7.0f;
    [SerializeField] private float _attackDist = 7.0f;

    public AiStates(GameObject _npc, NavMeshAgent _agent, List<GameObject> _food, GameObject _player)
    {
        npc = _npc;
        agent = _agent;
        food.AddRange(_food);
        player = _player;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public AiStates Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeeFood()
    {
        {
            foreach (GameObject f in food)
            {
                Vector3 dir = f.transform.position - npc.transform.position;
                float angle = Vector3.Angle(npc.transform.forward, dir);
                if (dir.magnitude < _visDist && angle < _visAngle)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(npc.transform.position, dir, out hit, _visDist))
                    {
                        if (hit.collider.gameObject.tag == "Food")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }


    public bool CanEatFood()
    {
        foreach (GameObject f in food)
        {
            Vector3 dir = f.transform.position - npc.transform.position;
            if (dir.magnitude < _eatDist)
            {
                return true;
            }
        }
        return false;
    }
    public bool CanSeePlayer()
    {
        {
            Vector3 dir = player.transform.position - npc.transform.position;
            float angle = Vector3.Angle(npc.transform.forward, dir);
            if (dir.magnitude < _visDist && angle < _visAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(npc.transform.position, dir, out hit, _visDist))
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public bool CanAttackPlayer()
    {
        Vector3 direction = player.transform.position - npc.transform.position;
        if (direction.magnitude < _attackDist)
        {
            return true;
        }
        return false;
    }




}

public class PatrolForFood : AiStates
{
    public PatrolForFood(GameObject _npc, NavMeshAgent _agent, List<GameObject> _food, GameObject _player)
        : base(_npc, _agent, _food, _player)
    {
        name = STATE.PATROLFORFOOD;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (CanSeeFood())
        {
            nextState = new PursueForFood(npc, agent, food, player);
            stage = EVENT.EXIT;
        }
        else if (Random.Range(0, 100) < 10)
        {
            nextState = new PatrolForFood(npc, agent, food, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class PursueForFood : AiStates
{
    int currentIndex = -1;

    public PursueForFood(GameObject _npc, NavMeshAgent _agent, List<GameObject> _food, GameObject _player)
        : base(_npc, _agent, _food, _player)
    {
        name = STATE.PURSUEFORFOOD;
        agent.speed = 1.5f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        float lastDistance = Mathf.Infinity;

        for (int i = 0; i < GameManager.instance.food.Count; i++)
        {
            GameObject thisFood = GameManager.instance.food[i];
            float distance = Vector3.Distance(npc.transform.position, thisFood.transform.position);
            if (distance < lastDistance)
            {
                currentIndex = i;
                lastDistance = distance;
            }

        }

        base.Enter();
    }

    public override void Update()
    {

        if (CanSeeFood())
        {
            nextState = new PursueForFood(npc, agent, food, player);
            stage = EVENT.EXIT;
        }
        else if (agent.remainingDistance < 1.0f)
        {
            currentIndex = (currentIndex + 1) % GameManager.instance.food.Count;
            agent.SetDestination(GameManager.instance.food[currentIndex].transform.position);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class PatrolForPlayer : AiStates
{
    public PatrolForPlayer(GameObject _npc, NavMeshAgent _agent, List<GameObject> _food, GameObject _player)
        : base(_npc, _agent, _food, _player)
    {
        name = STATE.PATROLFORPLAYER;
        agent.speed = 4.0f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (CanSeePlayer())
        {
            nextState = new PursueForPlayer(npc, agent, food, player);
            stage = EVENT.EXIT;
        }
        else if (Random.Range(0, 100) < 10)
        {
            nextState = new PatrolForPlayer(npc, agent, food, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class PursueForPlayer : AiStates
{

    public PursueForPlayer(GameObject _npc, NavMeshAgent _agent, List<GameObject> _food, GameObject _player)
        : base(_npc, _agent, _food, _player)
    {
        name = STATE.PURSUEFORPLAYER;
        agent.speed = 1.5f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        float lastDistance = Mathf.Infinity;
        float distance = Vector3.Distance(npc.transform.position, GameManager.instance.tempPlayer.transform.position);
        if (distance < lastDistance)
        {
            lastDistance = distance;
        }



        base.Enter();
    }

    public override void Update()
    {

        if (CanSeeFood())
        {
            nextState = new PursueForPlayer(npc, agent, food, player);
            stage = EVENT.EXIT;
        }
        else if (agent.remainingDistance < 1.0f)
        {
            agent.SetDestination(GameManager.instance.tempPlayer.transform.position);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}


