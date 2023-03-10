using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    const string HideKey = "Hide";
    const string ShowKey = "Show";
    [SerializeField] private Panel shopPanel;
    [SerializeField] private Panel mainWindowPanel;
    [SerializeField] SellWindowController sellWindowController;
    ItemType seletedTab;
    private Dictionary<Item, int> itemsToSell;
    private Dictionary<Item, int> selectedItems;
    private float totalPrice;

    private void Start()
    {
        ShowMainWindow();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ExitShop();

        if(Input.GetKeyDown(KeyCode.L))
            ShowShop();
    }

    private void TogglePos(Panel panel, string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    public void Sell()
    {
        Player.Instance.AddCoins(totalPrice);
        foreach(var item in selectedItems)
        {
            Player.Instance.RemoveItemToInventory(item.Key, item.Value);
        }
        selectedItems.Clear();
        SetItemsToSell();
        switch (seletedTab)
        {
            case ItemType.Clothes:
                SelectClothes();
                break;
            case ItemType.Fruit:
                SelectFruit();
                break;
            case ItemType.Gem:
                SelectGem();
                break;
            default:
                SelectMiscellaneous();
                break;
        }
    }

#region Sell Functions
    public void SelectItem(Item item, int quantitySelected)
    {
        Debug.Log("Selected Item: " + item.name + ", " + quantitySelected);
        selectedItems[item] = quantitySelected;
        UpdateTotalPrice();
    }

    public void UpdateTotalPrice()
    {
        totalPrice = 0;
        foreach(var item in selectedItems)
            totalPrice += (item.Key.price * item.Value);
        sellWindowController.SetTotalPriceText(totalPrice);
    }

    public void SelectClothes()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in itemsToSell)
            if(item.Key.type == ItemType.Clothes)
                tempItems[item.Key] = item.Value;
        PopulateFilteredItems(tempItems);
        seletedTab = ItemType.Clothes;
    }

    public void SelectFruit()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in itemsToSell)
            if(item.Key.type == ItemType.Fruit)
                tempItems[item.Key] = item.Value;
        PopulateFilteredItems(tempItems);
        seletedTab = ItemType.Fruit;
    }

    public void SelectGem()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in itemsToSell)
            if(item.Key.type == ItemType.Gem)
                tempItems[item.Key] = item.Value;
        PopulateFilteredItems(tempItems);
        seletedTab = ItemType.Gem;
    }

    public void SelectMiscellaneous()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in itemsToSell)
            if(item.Key.type == ItemType.Miscellaneous)
                tempItems[item.Key] = item.Value;
        PopulateFilteredItems(tempItems);
        seletedTab = ItemType.Miscellaneous;
    }

    public void PopulateFilteredItems(Dictionary<Item, int> filteredItems)
    {
        List<SellItemPortraitController> portraits = 
            sellWindowController.PopulateSellWindow(filteredItems, selectedItems);
        foreach(var portrait in portraits)
            portrait.AddOnEndEditListener(SelectItem);
        UpdateTotalPrice();
    }

    public void SetItemsToSell()
    {
        itemsToSell = new Dictionary<Item, int>(Player.Instance.inventory);
    }
#endregion

    // public void SetItemsToBuy(Dictionary<Item, int> items)
    // {
    //     itemsToBuy = new Dictionary<Item, int>(items);
    // }

#region UI Functions
    public void ShowShop()
    {
        selectedItems = new Dictionary<Item, int>();
        TogglePos(shopPanel, ShowKey);
    }

    public void HideShop()
    {
        TogglePos(shopPanel, HideKey);
    }

    public void ShowMainWindow()
    {
        TogglePos(mainWindowPanel, ShowKey);
    }

    public void HideMainWindow()
    {
        TogglePos(mainWindowPanel, HideKey);
    }

    public void ExitShop()
    {
        sellWindowController.Hide();
        // buyWindowController.Hide();
        ShowMainWindow();
        HideShop();
    }

    public void ShowSellWindow()
    {
        SetItemsToSell();
        SelectClothes();
        sellWindowController.Show();
        HideMainWindow();
    }

    public void ReturnSellWindow()
    {
        sellWindowController.Hide();
        ShowMainWindow();
    }

    // public void ShowBuyWindow()
    // {
    //     buyWindowController.Show();
    //     HideMainWindow();
    // }

    // public void ReturnBuyWindow()
    // {
    //     buyWindowController.Hide();
    //     ShowMainWindow();
    // }
#endregion
}
