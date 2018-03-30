using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public List<BaseStat> Stats { get; set; }

    public string ObjectSlug { get; set; }

    public string Description { get; set; }

    public string ActionName { get; set; }

    public string ItemName { get; set; }

    public bool ItemModifier { get; set; }

    public Item(List<BaseStat> _Stats, string _objectSlug)
    {
        Stats = _Stats;
        ObjectSlug = _objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _Stats, string _objectSlug, string _description, string _actionName, string _itemName, bool _itemModifire)
    {
        Stats = _Stats;
        ObjectSlug = _objectSlug;
        Description = _description;
        ActionName = _actionName;
        ItemName = _itemName;
        ItemModifier = _itemModifire;
    }
}