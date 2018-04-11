using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vampire : MonoBehaviour, IEnemy
{
    [SerializeField]
    private LayerMask aggroLayerMask;

    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maxHealth;

    public int ID { get; set; }
    public int Experience { get; set; }

    public DropTable DropTable { get; set; }

    public Spawner Spawner { get; set; }

    [SerializeField]
    private PickupItem pickupItem;

    private Player player;

    private NavMeshAgent navAgent;

    private CharacterStats characterStates;

    private Collider[] withinAggroColliders;

    // Use this for initialization
    private void Start()
    {
        DropTable = new DropTable();

        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("sword", 25),
            new LootDrop("staff", 25),
            new LootDrop("potion_log", 25)
        };

        ID = 1;

        Experience = 300;

        navAgent = GetComponent<NavMeshAgent>();

        characterStates = new CharacterStats(6, 10, 2);

        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);

        if (withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
    }

    private void ChasePlayer(Player player)
    {
        navAgent.SetDestination(player.transform.position);

        this.player = player;

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

    public void Die()
    {
        DropLoot();
    }

    private void DropLoot()
    {
        Item item = DropTable.GetDrop();

        if (item != null)
        {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);

            instance.ItemDrop = item;
        }
    }
}