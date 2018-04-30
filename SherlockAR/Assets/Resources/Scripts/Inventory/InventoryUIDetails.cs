using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    private Item item;
    private Button selectedItemButton, itemInteractButton;
    private Text itemNameText, itemDescription, itemInteractButtonText;

    public void Start()
    {
        itemNameText = transform.GetChild(1).GetComponent<Text>();
        itemDescription = transform.GetChild(0).GetComponent<Text>();
        itemInteractButton = transform.GetChild(2).GetComponent<Button>();
        itemInteractButtonText = itemInteractButton.transform.GetChild(0).GetComponent<Text>();
    }

    public void SetItem(Item item, Button selectButton)
    {
        print("Hi");
        this.item = item;

        this.selectedItemButton = selectButton;

        itemNameText.text = item.ItemName;

        itemDescription.text = item.Description;

        itemInteractButtonText.text = item.ActionName;

        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        if (item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquiItem(item);
            Destroy(selectedItemButton.gameObject);
        }
    }
}