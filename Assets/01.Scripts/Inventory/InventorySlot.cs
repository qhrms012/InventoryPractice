using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image itemIcon; 
    public ItemData itemData; 

    private Transform originalParent;
    private Canvas canvas;

    private GameObject draggingIcon;

    public Inventory inventory;         // 이 슬롯이 속한 인벤토리
    public int index;                   // 이 슬롯의 인벤토리 인덱스


    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        UpdateSlotUI();
    }

    public void SetItem(ItemData newItem)
    {
        itemData = newItem;
        UpdateSlotUI();
    }

    private void UpdateSlotUI()
    {
        itemIcon.sprite = itemData ? itemData.itemIcon : null;
        itemIcon.enabled = itemData != null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemData == null) return;

        draggingIcon = new GameObject("Dragging Icon");
        draggingIcon.transform.SetParent(canvas.transform, false);
        var img = draggingIcon.AddComponent<Image>();
        img.sprite = itemData.itemIcon;
        img.raycastTarget = false;

        draggingIcon.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingIcon != null)
            draggingIcon.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggingIcon != null)
            Destroy(draggingIcon);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedSlot = eventData.pointerDrag?.GetComponent<InventorySlot>();
        if (draggedSlot != null && draggedSlot != this)
        {
            SwapItems(draggedSlot);
        }
    }

    private void SwapItems(InventorySlot otherSlot)
    {
        // 인벤토리의 ItemData도 교체
        var temp = inventory.items[index];
        inventory.items[index] = otherSlot.inventory.items[otherSlot.index];
        otherSlot.inventory.items[otherSlot.index] = temp;

        // UI 업데이트
        inventory.GetComponent<InventoryUI>().UpdateInventoryUI();
    }

}
