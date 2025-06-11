using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemPanel;
    public GameObject itemSlot;
    private List<GameObject> itemSlots = new List<GameObject>();

    public void UpdateInventoryUI()
    {
        foreach (var slot in itemSlots) Destroy(slot);
        itemSlots.Clear();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            ItemData item = inventory.items[i];
            GameObject slot = Instantiate(itemSlot, itemPanel);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
            slot.GetComponentInChildren<Image>().sprite = item.itemIcon;

            var inventorySlot = slot.GetComponent<InventorySlot>();
            inventorySlot.itemData = item;
            inventorySlot.inventory = inventory;
            inventorySlot.index = i;

            itemSlots.Add(slot);
        }


    }

    public void CreateInventorySlot(ItemData item)
    {
        GameObject slot = Instantiate(itemSlot, itemPanel);
        slot.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
        slot.GetComponentInChildren<Image>().sprite = item.itemIcon;
    }
    
}
