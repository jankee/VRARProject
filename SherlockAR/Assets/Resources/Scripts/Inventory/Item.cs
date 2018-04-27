using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { Weapon, Consumable, Quest }

    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string Description { get; set; }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }

    public string ActionName { get; set; }
    public string ItemName { get; set; }
    public bool ItemModifier { get; set; }

    public Item(List<BaseStat> stats, string objectSlug)
    {
        this.Stats = stats;
        this.ObjectSlug = objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> stats, string objectSlug, string description, ItemTypes itemType, string actionName, string itemName, bool itemModifier)
    {
        this.Stats = stats;
        this.ObjectSlug = objectSlug;
        this.Description = description;
        this.ItemType = itemType;
        this.ActionName = actionName;
        this.ItemName = itemName;
        this.ItemModifier = itemModifier;
    }
}