using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;

    private InventoryUIItem itemContainer { get; set; }
    private List<InventoryUIItem> itemUIList = new List<InventoryUIItem>();
    private bool menuIsActive { get; set; }
    private Item currentSelectedItem { get; set; }

    // Use this for initialization
    private void Start()
    {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;

            inventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }

    // Update is called once per frame
    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
}