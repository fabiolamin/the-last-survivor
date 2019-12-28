using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent enemyNavMeshAgent;
    private EnemyAnimation enemyAnimation;
    [SerializeField]
    private float speed = 3f;
    Transform target;

    private void Awake()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyNavMeshAgent.speed = speed;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        if(enemyAnimation.IsAttacking)
        {
            Stop();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        enemyNavMeshAgent.isStopped = false;
        enemyNavMeshAgent.destination = target.position;
    }

    private void Stop()
    {
        enemyNavMeshAgent.isStopped = true;
    }
}
