using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    private void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your Power level."));
        stats.Add(new BaseStat(5, "Tougness", "Your Toughness level."));
        stats.Add(new BaseStat(2, "Atk Spd", "Your AttackSpeed level."));
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
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