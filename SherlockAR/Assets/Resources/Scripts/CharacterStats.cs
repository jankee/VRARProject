using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    private void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your Power level."));
        stats.Add(new BaseStat(5, "Vitality", "Your Vitality level."));
    }

    public void AddStatBonus(List<BaseStat> baseStats)
    {
        foreach (BaseStat baseStat in baseStats)
        {
            stats.Find(x => x.StatName == baseStat.StatName).AddStatBonus(new StatBonus(baseStat.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> baseStates)
    {
        foreach (BaseStat baseStat in baseStates)
        {
            stats.Find(x => x.StatName == baseStat.StatName).RemoveStatBonus(new StatBonus(baseStat.BaseValue));
        }
    }
}