using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;

    public float currentHealth;

    public float maxHealth;

    private void Awake()
    {
        this.currentHealth = maxHealth;
        characterStats = new CharacterStats(10, 10, 10);
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
        print("Player dead. Reset Health.");
        currentHealth = maxHealth;
    }
}