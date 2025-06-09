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
        var tempData = itemData;
        SetItem(otherSlot.itemData);
        otherSlot.SetItem(tempData);
    }
}
