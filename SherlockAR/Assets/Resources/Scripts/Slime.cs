using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    [SerializeField]
    private float currentHealth, power, toughness;

    [SerializeField]
    private float maxHealth;

    private CharacterStats characterStats;

    private void Start()
    {
        characterStats = new CharacterStats(6, 10, 2);

        currentHealth = maxHealth;
    }

    private void Update()
    {
    }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}