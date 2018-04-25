using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }

    private List<Item> Items { get; set; }

    // Use this for initialization
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        BuildDatabase();
    }

    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());

        print(Items.Count);
        foreach (Item item in Items)
        {
            for (int i = 0; i < item.Stats.Count; i++)
            {
                print(item.Stats[i].StatName);
                print(item.Stats[i].GetCalculatedStatValue());
            }
        }
    }
}