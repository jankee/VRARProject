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

    public Item(List<BaseStat> _Stats, string _objectSlug)
    {
        Stats = _Stats;
        ObjectSlug = _objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _Stats, string _objectSlug, string _description, ItemTypes _itemType, string _actionName, string _itemName, bool _itemModifire)
    {
        Stats = _Stats;
        ObjectSlug = _objectSlug;
        Description = _description;
        ItemType = _itemType;
        ActionName = _actionName;
        ItemName = _itemName;
        ItemModifier = _itemModifire;
    }
}