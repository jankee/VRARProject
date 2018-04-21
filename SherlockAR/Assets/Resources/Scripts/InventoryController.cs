using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;

    public Item sword;

    private void Start()
    {
        playerWeaponController = this.GetComponent<PlayerWeaponController>();

        List<BaseStat> swordStats = new List<BaseStat>();

        swordStats.Add(new BaseStat(6, "Power", "Your Power level."));

        sword = new Item(swordStats, "sword");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}