using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    public float currentHealth;
    public float maxHealth;

    private Player player;

    private CharacterStats characterStats;

    private NavMeshAgent navAgent;

    private Collider[] withinAggroColliders;

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        characterStats = new CharacterStats(6, 10, 2);

        currentHealth = maxHealth;
    }

    public void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10f, aggroLayerMask);

        if (withinAggroColliders.Length > 0)
        {
            ChesePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
    }

    public void PerformAttack()
    {
        player.TakeDamage(5);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ChesePlayer(Player player)
    {
        this.player = player;

        navAgent.SetDestination(player.transform.position);

        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", 0.5f, 2f);
            }
        }
        else
        {
            CancelInvoke("PerformAttack");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}