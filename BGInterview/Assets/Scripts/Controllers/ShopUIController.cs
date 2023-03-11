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
    [SerializeField] BuyWindowController buyWindowController;
    ItemType seletedTab;
    private Dictionary<Item, int> itemsToSell;
    private List<Clothes> clothesToBuy;
    private Dictionary<Item, int> selectedItems;
    private float totalPrice;
    public List<Clothes> clothesTest;

    private void Start()
    {
        ShowMainWindow();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ExitShop();

        if(Input.GetKeyDown(KeyCode.L)){
            ShowShop();
            SetItemsToBuy(clothesTest);
        }
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

    public void BuyItem(Item item, BodyParts bodyPart)
    {
        bool hasMoney = Player.Instance.RemoveCoins(item.price);
        if(hasMoney){
            Player.Instance.AddItemToInventory(item);
            switch (bodyPart)
            {
                case BodyParts.Head:
                    Head head = item as Head;
                    Debug.Log("Head: " + head.headFront);
                    buyWindowController.heads.Remove(head);
                    break;
                case BodyParts.Body:
                    Body body = item as Body;
                    buyWindowController.bodies.Remove(body);
                    break;
                case BodyParts.Legs:
                    Legs legs = item as Legs;
                    buyWindowController.legs.Remove(legs);
                    break;
                default:
                    break;
            }
        } else{
            Debug.Log("Player doesn't have money to buy " + item.itemName);
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

#region Buy Functions
    public void BuyHead()
    {
        Item itemToBuy = buyWindowController.heads[buyWindowController.currentHead];
        BuyItem(itemToBuy, BodyParts.Head);
    }

    public void BuyBody()
    {
        Item itemToBuy = buyWindowController.bodies[buyWindowController.currentBody];
        BuyItem(itemToBuy, BodyParts.Body);
    }

    public void BuyLegs()
    {
        Item itemToBuy = buyWindowController.legs[buyWindowController.currentLegs];
        BuyItem(itemToBuy, BodyParts.Legs);
    }

    public void SetItemsToBuy(List<Clothes> clothes)
    {
        clothesToBuy = new List<Clothes>(clothes);
    }
#endregion

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
        buyWindowController.Hide();
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

    public void ShowBuyWindow()
    {
        buyWindowController.PopulateBuyItems(clothesToBuy);
        buyWindowController.Show();
        HideMainWindow();
    }

    public void ReturnBuyWindow()
    {
        buyWindowController.Hide();
        ShowMainWindow();
    }
#endregion
}
