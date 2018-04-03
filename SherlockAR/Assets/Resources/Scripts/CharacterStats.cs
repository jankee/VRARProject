using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int power, int toughness, int attackSpeed)
    {
        stats = new List<BaseStat>() { new BaseStat(BaseStat.BaseStatType.Power, power, "Power"),
        new BaseStat(BaseStat.BaseStatType.Toughness, toughness, "Toughness"),
        new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "AttackSpeed")};
    }

    //private void Start()
    //{
    //    stats.Add(new BaseStat(4, "Power", "Your power level."));
    //    stats.Add(new BaseStat(2, "Toughness", "Your vitality level."));

    //    Debug.Log("stats[0] : " + stats[0].GetCalculatedStatValue());
    //}

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            //statBonus2 = statBonus;
            stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    //BaseStat statBonus2;
    //private bool OOOO(BaseStat x)
    //{
    //    return x.StatName == statBonus.StatName;
    //}
}