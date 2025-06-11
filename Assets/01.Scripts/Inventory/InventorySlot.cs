using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public ItemData itemData;
    public Inventory inventory;
    public int index;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;                 // �� ������ �κ��丮 �ε���


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>(); // �ڵ����� �ٿ��ֱ�
        }
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.lossyScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherSlot = eventData.pointerDrag?.GetComponent<InventorySlot>();
        if (otherSlot != null && otherSlot != this)
        {
            var temp = inventory.items[index];
            inventory.items[index] = inventory.items[otherSlot.index];
            inventory.items[otherSlot.index] = temp;

            FindObjectOfType<InventoryUI>().UpdateInventoryUI();
        }
    }

}
