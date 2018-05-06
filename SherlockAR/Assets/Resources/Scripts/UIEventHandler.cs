using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);

    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);

    public delegate void StatsEventHandler();

    public delegate void PlayerLevelEventHandler();

    public static event ItemEventHandler OnItemAddedToInventroy;

    public static event ItemEventHandler OnItemEquipped;

    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    public static event StatsEventHandler OnStatsChanged;

    public static event PlayerLevelEventHandler OnPlayerLevel;

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventroy(item);
    }

    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        OnPlayerHealthChanged(currentHealth, maxHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLeveled()
    {
        OnPlayerLevel();
    }
}