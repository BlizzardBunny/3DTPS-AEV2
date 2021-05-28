using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Animator rabbitAnimator;
    [SerializeField] CapsuleCollider triggerCollider;

    NavMeshAgent navMeshAgent;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {        
        if (isProvoked)
        {
            EngageTarget();
        }
    }

    private void EngageTarget()
    {
        rabbitAnimator.SetBool("Move", true);
        navMeshAgent.SetDestination(target.position);
    }

    public void SetIsProvoked(bool i)
    {
        isProvoked = i;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
