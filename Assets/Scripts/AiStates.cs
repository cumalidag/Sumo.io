using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiStates
{
    public enum STATE
    {
        IDLE,
        PATROL,
        PURSUE,
        ATTACK
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
    protected List<Transform> food;
    protected AiStates nextState;
    protected NavMeshAgent agent;
    protected GameObject player;

    [SerializeField] private float _visDist = 10.0f;
    [SerializeField] private float _visAngle = 30.0f;
    [SerializeField] private float _eatDist = 7.0f;
    [SerializeField] private float _attackDist = 7.0f;

    public AiStates(GameObject _npc, NavMeshAgent _agent, List<Transform> _food, GameObject _player)
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
            foreach (Transform f in food)
            {
                Vector3 dir = f.position - npc.transform.position;
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
        foreach (Transform f in food)
        {
            Vector3 dir = f.position - npc.transform.position;
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

    public class Idle : AiStates
    {
        public Idle(GameObject _npc, NavMeshAgent _agent, List<Transform> _food, GameObject _player)
            : base(_npc, _agent, _food, _player)
        {
            name = STATE.IDLE;
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
               // nextState = new Pursue(npc, agent, food, player);
                stage = EVENT.EXIT;
            }    
            else if (Random.Range(0,100) < 10)
            {
                nextState = new Patrol(npc, agent, food, player);
                stage = EVENT.EXIT;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
    
    public class Patrol : AiStates
    {
        int currentIndex = -1;

        public Patrol(GameObject _npc, NavMeshAgent _agent, List<Transform> _food, GameObject _player)
            : base(_npc, _agent, _food, _player)
        {
            name = STATE.PATROL;
            agent.speed = 1.5f;
            agent.isStopped = false;
        }

        public override void Enter()
        {
            float lastDistance = Mathf.Infinity;

            foreach (Transform f in food)
            {
               // GameObject thisFood = 
            }
        }
    }


}
