using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    public Inventory inventory;
    public ItemData testItem;
    public ItemData testItem2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            inventory.AddItem(testItem);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            inventory.AddItem(testItem2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var hoveredSlot = InventorySlot.currentHoveredSlot;
            if (hoveredSlot != null)
            {
                inventory.RemoveItem(hoveredSlot.index);
            }
        }
    }


}
