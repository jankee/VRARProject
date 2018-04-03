using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }

    public PlayerWeaponController playerWeaponController;

    public ConsumableController consumableControlller;

    public InventoryUIDetails inventoryUIDetailsPanel;

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

        //inventoryUIDetailsPanel = GetComponent<InventoryUIDetails>();

        GiveItem("sword");

        GiveItem("potion_log");
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryUIDetailsPanel.SetItem(item, selectedButton);
    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);

        playerItmes.Add(item);

        print(playerItmes.Count + " items in inventory. Added: " + itemSlug);

        UIEventHandler.ItemAddedToInventory(item);
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