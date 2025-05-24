using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int staringHealth;
    [SerializeField] private float hitInterval = 0.5f;
    [SerializeField] private int healthGainedPerLevel = 10;


    private float lastHitTime = 0;
    private int currentHealth;
    private int currentMaxHealth;
    private Animator animator;

    public static bool isAlive = true;
    // Start is called before the first frame update

    private void Awake()
    {
        currentHealth = staringHealth;
        currentMaxHealth = staringHealth;
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    public void OnLevelGained(int newLevel)
    {
        currentMaxHealth = staringHealth + (newLevel - 1) * healthGainedPerLevel;
        currentHealth = currentMaxHealth;
    }

    public float GetHealthRatio()
    {
        return (float)currentHealth / (float)currentMaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeapon") && isAlive && Time.time - lastHitTime > hitInterval)
        {
            TakeDamage(5);
        }
    }

    private void TakeDamage(int damage)
    {
        Debug.Log("DamageTake");
        lastHitTime = Time.time;
        currentHealth -= damage;
        Debug.Log("Current Health " + currentHealth);
        if(currentHealth > 0)
            animator.SetTrigger("hit");
        else
        {
            Debug.Log("elseDamageTake");
            isAlive = false;
            animator.SetTrigger("death");
        }
    }
}
