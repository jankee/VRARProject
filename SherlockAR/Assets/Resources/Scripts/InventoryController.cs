using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }

    public PlayerWeaponController playerWeaponController;

    public ConsumableController consumableController;

    //public Item sword;

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
}