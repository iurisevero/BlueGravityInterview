using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPortraitController : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] private TextMeshProUGUI price;
    public Item item;

    public void SetItem(Item _item, int _quantity = 1)
    {
        item = _item;
        itemImage.sprite = item.itemSprite;
        price.text = item.price.ToString();
        quantity.text = _quantity.ToString();
    }

    public Image GetItemImage()
    {
        return itemImage;
    }
}
