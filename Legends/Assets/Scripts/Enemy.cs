using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
 public Transform target;
    [SerializeField] private Collider swordCollider;
    [SerializeField] private float hitInterval = 0.5f;
    [SerializeField] private float lastAttackTime;
    [SerializeField] private float AttackInterval;
    private NavMeshAgent agent;
    private Animator animator;
    public bool isDead = false;

    private void Start()
    {
        swordCollider.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    public void OnDeath()
    {
        isDead = true;
        Debug.Log("Orc dead");
        agent.isStopped = false;
    }

    private void Update()
    {
        if(isDead)
            return;
        if (Vector3.Distance(transform.position, target.position) > 2f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            animator.SetBool("running", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("running", false);
            if (Time.time - lastAttackTime > AttackInterval)
            {
                lastAttackTime = Time.time;
                animator.SetTrigger("attack");
            }
            
        }
    }

    public void StartAttack()
    {
        swordCollider.enabled = true;
    }

    public void EndAttack()
    {
        swordCollider.enabled = false;
    }
}
