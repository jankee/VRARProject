using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    private CharacterStats stats;

    public void Start()
    {
        stats = GetComponent<Player>().characterStats;
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemTemp = Resources.Load<GameObject>("Consumables/" + item.ObjectSlug);

        GameObject itemToSpawn = Instantiate(itemTemp, this.transform.position, Quaternion.identity);

        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
    }
}