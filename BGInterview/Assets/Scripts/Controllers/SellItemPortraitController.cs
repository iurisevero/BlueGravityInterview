using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SellItemPortraitController : MonoBehaviour
{
    [SerializeField] private ItemPortraitController itemPortraitController;
    [SerializeField] private TMP_InputField inputField;
    private int totalQuantity = 0;
    public int currentQuantity = 0;

    public void AddOnEndEditListener(Action<Item, int> action)
    {
        inputField.onEndEdit.RemoveAllListeners();
        inputField.onEndEdit.AddListener(delegate{ 
            action(itemPortraitController.item, currentQuantity);
        });
    }

    public void CheckInput(string inputValue)
    {
        currentQuantity = int.Parse(inputValue);
        if(currentQuantity < 0)
            currentQuantity = 0;
        if(currentQuantity > totalQuantity)
            currentQuantity = totalQuantity;
        inputField.text = currentQuantity.ToString();
    }

    public void SetItem(Item _item, int _quantity = 1, int _selectedQuantity = 0)
    {
        totalQuantity = _quantity;
        itemPortraitController.SetItem(_item, _quantity);
        inputField.text = _selectedQuantity.ToString();
    }

    public Tuple<Item, int> GetItem()
    {
        return new Tuple<Item, int>(itemPortraitController.item, currentQuantity);
    } 
}
