using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);

    public static event ItemEventHandler OnItemAddedToInventroy;

    public static void ItemAddedToInventory()
    {
    }
}