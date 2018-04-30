using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    private Item item;
    private Button selectedItemButton, itemInteractButton;
    private Text itemNameText, itemDescription, itemInteractButtonText;

    public Text statText;

    public void Start()
    {
        itemNameText = transform.GetChild(1).GetComponent<Text>();
        itemDescription = transform.GetChild(0).GetComponent<Text>();
        itemInteractButton = transform.GetChild(2).GetComponent<Button>();
        itemInteractButtonText = itemInteractButton.transform.GetChild(0).GetComponent<Text>();
        statText = transform.GetChild(3).GetChild(0).GetComponent<Text>();

        RemoveItem();
    }

    public void SetItem(Item item, Button selectButton)
    {
        this.gameObject.SetActive(true);

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
        item = null;

        RemoveItem();
    }

    public void RemoveItem()
    {
        this.gameObject.SetActive(false);
    }
}