using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;

    public int currentHealth;

    public int maxHealth;

    private void Start()
    {
        this.currentHealth = this.maxHealth;

        characterStats = new CharacterStats(2, 5, 8);

        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    public void TakeDamage(int amount)
    {
        print("take damage : " + amount);

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }

        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    private void Die()
    {
        print("Player dead. Reset health.");

        this.currentHealth = this.maxHealth;

        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }
}