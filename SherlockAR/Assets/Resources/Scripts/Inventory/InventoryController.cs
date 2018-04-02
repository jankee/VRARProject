using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }

    public PlayerWeaponController playerWeaponController;

    public ConsumableController consumableControlller;

    public List<Item> playerItmes = new List<Item>();

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

        playerWeaponController = GetComponent<PlayerWeaponController>();

        consumableControlller = GetComponent<ConsumableController>();
    }

    public void GiveItem(string itemSlug)
    {
        playerItmes.Add(ItemDatabase.Instance.GetItem(itemSlug));

        print(playerItmes.Count + " items in inventory. Added: " + itemSlug);
    }

    public void EquipItme(Item itmeToEquip)
    {
        playerWeaponController.EquipWeapon(itmeToEquip);
    }

    public void ConsumeItme(Item itemToConsume)
    {
        consumableControlller.ConsumeItem(itemToConsume);
    }
}