using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SellItemPortraitController : MonoBehaviour
{
    [SerializeField] private ItemPortraitController itemPortraitController;
    [SerializeField] private TMP_InputField inputField;
    private int totalQuantity = 0;
    public int currentQuantity = 0;

    public void CheckInput(string inputValue)
    {
        currentQuantity = int.Parse(inputValue);
        if(currentQuantity < 0)
            currentQuantity = 0;
        if(currentQuantity > totalQuantity)
            currentQuantity = totalQuantity;
        inputField.text = currentQuantity.ToString();
    }

    public void SetItem(Item _item, int _quantity = 1)
    {
        totalQuantity = _quantity;
        itemPortraitController.SetItem(_item, _quantity);
    }
}
