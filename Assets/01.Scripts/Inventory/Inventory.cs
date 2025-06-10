using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    
    public void AddItem(ItemData item)
    {
        items.Add(item);
    }
    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }

    public void DropItem(ItemData item, Vector3 dropPosition)
    {
        items.Remove(item);
    }
}
