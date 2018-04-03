using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    private Item item;

    private Button selectedItemButton, itemInteractButton;

    private Text itemNameText, itemDescriptionText, itemInteractButtonText;

    public Text statText;

    private void Start()
    {
        itemNameText = transform.Find("Item_Name").GetComponent<Text>();

        itemDescriptionText = transform.Find("Item_Description").GetComponent<Text>();

        itemInteractButton = transform.Find("Button").GetComponent<Button>();

        itemInteractButtonText = itemInteractButton.transform.GetChild(0).GetComponent<Text>();

        gameObject.SetActive(false);
    }

    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats)
            {
                statText.text += stat.StatName + ": " + stat.BaseValue + "\n";
            }
        }

        itemInteractButton.onClick.RemoveAllListeners();
        this.item = item;
        this.selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractButtonText.text = item.ActionName;

        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        if (item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItme(item);

            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItme(item);

            Destroy(selectedItemButton.gameObject);
        }

        item = null;

        gameObject.SetActive(false);
    }
}