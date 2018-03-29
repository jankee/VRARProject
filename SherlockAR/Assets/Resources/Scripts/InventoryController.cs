using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;

    public Item sword;

    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();

        List<BaseStat> swordStaes = new List<BaseStat>();

        swordStaes.Add(new BaseStat(6, "Power", "Your power level."));

        sword = new Item(swordStaes, "sword");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}