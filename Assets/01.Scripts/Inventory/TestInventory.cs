using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;
    public ItemData itemData;


    void Start()
    {
        inventory.AddItem(itemData);
        inventoryUI.UpdateInventoryUI();
    }

    
}
