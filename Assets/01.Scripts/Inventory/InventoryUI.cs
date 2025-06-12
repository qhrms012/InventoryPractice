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
        foreach (GameObject slot in itemSlots)
            Destroy(slot);
        itemSlots.Clear();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            var item = inventory.items[i];
            GameObject slot = Instantiate(itemSlot, itemPanel);
            var slotScript = slot.GetComponent<InventorySlot>();

            slotScript.itemData = item;
            slotScript.inventory = inventory;
            slotScript.index = i;

            var image = slot.GetComponentInChildren<Image>();
            var text = slot.GetComponentInChildren<TextMeshProUGUI>();

            if (item != null)
            {
                image.sprite = item.itemIcon;
                text.text = item.itemName;
            }
            else
            {
                image.sprite = null;
                text.text = "";
            }

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
