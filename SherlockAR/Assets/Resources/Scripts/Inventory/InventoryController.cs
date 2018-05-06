using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }

    public PlayerWeaponController playerWeaponController;

    public ConsumableController consumableController;

    public InventoryUIDetails inventoryDetailsPanel;

    public List<Item> playerItems = new List<Item>();

    //public Item PotionLog;

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

        playerWeaponController = this.GetComponent<PlayerWeaponController>();

        consumableController = this.GetComponent<ConsumableController>();

        GiveItem("sword");

        GiveItem("staff");

        GiveItem("potion_log");

        //List<BaseStat> swordStats = new List<BaseStat>();

        //swordStats.Add(new BaseStat(6, "Power", "Your Power level."));

        //sword = new Item(swordStats, "staff");

        //PotionLog = new Item(new List<BaseStat>(), "potion_log", "Drink this to log something cool!", "Drink", "Log Potion", false);
    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        playerWeaponController.EquipWeapon(sword);

    //        consumableController.ConsumeItem(PotionLog);
    //    }
    //}

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);

        playerItems.Add(item);

        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquiItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }
}