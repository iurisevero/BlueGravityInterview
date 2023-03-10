using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public Sprite itemSprite;
    public float price;
    public bool consumable;

    public virtual void Use()
    {
        Debug.Log(itemName + " used");
    }
}
