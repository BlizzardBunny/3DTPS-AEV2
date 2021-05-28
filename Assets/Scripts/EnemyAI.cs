using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Animator rabbitAnimator;

    NavMeshAgent navMeshAgent;
    [SerializeField] bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {        
        if (isProvoked)
        {
            rabbitAnimator.SetTrigger("Move");            
            EngageTarget();
        }
    }

    private void EngageTarget()
    {        
        navMeshAgent.SetDestination(target.position);
    }

    public void SetIsProvoked(bool i)
    {
        isProvoked = i;
    }

    public Animator GetRabbitAnimator()
    {
        return rabbitAnimator;
    }
}
