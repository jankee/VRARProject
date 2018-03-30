using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Newtonsoft.Json;

public class BaseStat
{
    public List<StatBonus> BaseAdditives { get; set; }

    public int BaseValue { get; set; }

    public string StatName { get; set; }

    public string StatDesctiption { get; set; }

    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        BaseAdditives = new List<StatBonus>();

        BaseValue = baseValue;

        StatName = statName;

        StatDesctiption = statDescription;
    }

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(int baseValue, string statName)
    {
        BaseAdditives = new List<StatBonus>();

        BaseValue = baseValue;

        StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        FinalValue = 0;
        BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;

        Debug.Log("FinalValue : " + FinalValue);
        return FinalValue;
    }
}