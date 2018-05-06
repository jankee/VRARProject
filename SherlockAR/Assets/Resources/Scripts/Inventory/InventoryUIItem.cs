using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;

    [SerializeField]
    private Text itemText;

    [SerializeField]
    private Image itemImage;

    public void SetItem(Item item)
    {
        this.item = item;

        //print(item.Stats[0].StatType);

        //itemText = this.transform.GetChild(1).GetComponent<Text>();
        //itemImage = this.transform.GetChild(0).GetComponent<Image>();

        SetupItemValue();
    }

    private void SetupItemValue()
    {
        itemText.text = item.ItemName;
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        print(itemImage.name);
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}