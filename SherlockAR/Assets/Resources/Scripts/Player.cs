using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;

    public int currentHealth;

    public int maxHealth;

    public PlayerLevel PlayerLevel { get; set; }

    private void Start()
    {
        PlayerLevel = GetComponent<PlayerLevel>();

        this.currentHealth = this.maxHealth;
        characterStats = new CharacterStats(10, 10, 10);

        //UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    private void Die()
    {
        print("Player dead. Reset Health.");
        currentHealth = maxHealth;
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }
}