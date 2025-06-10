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
        // 기존 슬롯 삭제
        foreach (GameObject slot in itemSlots)
        {
            Destroy(slot);
        }
        itemSlots.Clear();

        // 새로운 슬롯 생성
        foreach (ItemData item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlot, itemPanel);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
            slot.GetComponentInChildren<Image>().sprite = item.itemIcon;
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
