using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        Melee,
        Range
    }
    [Header("Main Info")]
    public ItemType Type;
    public int itemId;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
}
