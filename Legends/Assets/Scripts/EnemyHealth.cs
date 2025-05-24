using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private float hitInterval;
    [SerializeField] private int xpToGive = 20;
    public UnityEvent OnDeath;

    private float lastHitTime = 0;
    private int currentHealth;
    private Animator animator;
    private bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon") && !isDead 
            && Time.time -lastHitTime > hitInterval)
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        lastHitTime = Time.time;
        currentHealth -= damage;
        if (currentHealth > 0)
            animator.SetTrigger("hit");
        else
        {
            LevelManager.instance.GiveXP(xpToGive);
            animator.ResetTrigger("attack");
            animator.SetTrigger("dead");
            OnDeath.Invoke();
            isDead = true;
        }
    }
}
