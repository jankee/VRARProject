using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour, IEnemy
{
    [SerializeField]
    private LayerMask aggroLayerMask;

    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maxHealth;

    public int Experience { get; set; }

    public DropTable DropTable { get; set; }

    private Player player;

    private NavMeshAgent navAgent;

    private CharacterStats characterStats;

    private Collider[] withinAggroColliders;

    private void Start()
    {
        DropTable = new DropTable();

        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("sword", 25),
            new LootDrop("staff", 25),
            new LootDrop("potion_log", 25)
        };

        Experience = 250;

        navAgent = GetComponent<NavMeshAgent>();

        characterStats = new CharacterStats(6, 10, 2);

        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);

        if (withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
            print("Found Player I think.");
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

    private void ChasePlayer(Player player)
    {
        navAgent.SetDestination(player.transform.position);

        this.player = player;
        //print("remainingDistance : " + navAgent.remainingDistance + ", stoppingDistance : " + navAgent.stoppingDistance);
        if (navAgent.remainingDistance >= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                print("Attack Player!!");
                InvokeRepeating("PerformAttack", 0.5f, 2f);
            }
        }
        else
        {
            print("Not within distance.");

            CancelInvoke("PerformAttack");
        }
    }

    public void Die()
    {
        DropLoot();

        CombatEvent.EnemyDied(this);

        Destroy(gameObject);
    }

    private void DropLoot()
    {
    }
}