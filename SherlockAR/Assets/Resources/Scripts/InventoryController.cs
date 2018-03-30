using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }

    public PlayerWeaponController playerWeaponController;

    public ConsumableController consumableControlller;

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
}