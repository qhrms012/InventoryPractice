using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSlotCount = 20;
    public List<ItemData> items = new List<ItemData>();

    private void Awake()
    {
        // �ʱ�ȭ �� null�� ä��
        for (int i = 0; i < maxSlotCount; i++)
        {
            items.Add(null);
            FindObjectOfType<InventoryUI>().UpdateInventoryUI();
        }
    }
    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                FindObjectOfType<InventoryUI>().UpdateInventoryUI();
                return true;
            }
        }
        

        Debug.Log("�κ��丮�� ���� á���ϴ�.");
        return false;
    }
    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index] = null;
        }
    }

    public void DropItem(ItemData item, Vector3 dropPosition)
    {
        items.Remove(item);
    }
}
