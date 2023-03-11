using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    const string HideKey = "Hide";
    const string ShowKey = "Show";
    const string InventoryItemPoolKey = "InventoryUIController.InventoryItem";
    [SerializeField] private Panel panel;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private RectTransform itemsContainer;
    [SerializeField] private GameObject mainWindow;
    [SerializeField] private ChangeClothesWindowController changeClothesWindowController;
    private bool isOpen = false;
    private Item selectedItem;
    private Image selectedItemImage;
    private ItemType seletedTab;

    private void Start()
    {
        GameObjectPoolController.AddEntry(InventoryItemPoolKey, inventoryItemPrefab, 3, 10);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            ToogleInventory();
    }

    private void DeselectItem()
    {
        selectedItemImage.color = Color.white;
        selectedItemImage = null;
        selectedItem = null;
    }

    private void SelectItem(Item item, Image itemImage)
    {
        if(selectedItemImage != null)
                selectedItemImage.color = Color.white;

        selectedItem = item;
        selectedItemImage = itemImage;
        selectedItemImage.color = Color.yellow;
    }

    private void TogglePos(Panel panel, string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    private ItemPortraitController Dequeue(){
        Poolable p = GameObjectPoolController.Dequeue(InventoryItemPoolKey);
        ItemPortraitController portraitController = p.GetComponent<ItemPortraitController>();
        portraitController.transform.localScale = Vector3.one;
        portraitController.gameObject.SetActive(true);
        return portraitController;
    }

    private void Enqueue(GameObject portraitObject){
        Poolable p = portraitObject.GetComponent<Poolable>();
        GameObjectPoolController.Enqueue(p);
    }

    public void Use()
    {
        if(selectedItem == null)
            return;

        selectedItem.Use();
        if(selectedItem.consumable)
            Player.Instance.RemoveItemToInventory(selectedItem);
        DeselectItem();
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

    public void ToogleSelectItem(Item item, Image itemImage)
    {
        if(item == selectedItem){
            DeselectItem();
        } else{
            SelectItem(item, itemImage);
        }
    }

    public void PopulateInventoryWindow(Dictionary<Item, int> items)
    {
        Clear();
        foreach(var item in items){
            ItemPortraitController portraitController = Dequeue();
            Debug.Log("Inventory Item: " + item.Key.itemName);
            portraitController.SetItem(item.Key, item.Value);
            portraitController.transform.SetParent(itemsContainer, false);
            Button button = portraitController.gameObject.GetComponent<Button>();
            if(button == null)
                button = portraitController.gameObject.AddComponent<Button>();
            button.onClick.AddListener(delegate { 
                ToogleSelectItem(item.Key, portraitController.GetItemImage()); 
            });
            button.targetGraphic = portraitController.GetItemImage();
            ColorBlock buttonColors = button.colors;
            buttonColors.highlightedColor = new Color32(245, 245, 245, 185);
            button.colors = buttonColors;
        }
    }

    public void SelectClothes()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in Player.Instance.inventory)
            if(item.Key.type == ItemType.Clothes)
                tempItems[item.Key] = item.Value;
        PopulateInventoryWindow(tempItems);
        seletedTab = ItemType.Clothes;
    }

    public void SelectFruit()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in Player.Instance.inventory)
            if(item.Key.type == ItemType.Fruit)
                tempItems[item.Key] = item.Value;
        PopulateInventoryWindow(tempItems);
        seletedTab = ItemType.Fruit;
    }

    public void SelectGem()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in Player.Instance.inventory)
            if(item.Key.type == ItemType.Gem)
                tempItems[item.Key] = item.Value;
        PopulateInventoryWindow(tempItems);
        seletedTab = ItemType.Gem;
    }

    public void SelectMiscellaneous()
    {
        Dictionary<Item, int> tempItems = new Dictionary<Item, int>();
        foreach(var item in Player.Instance.inventory)
            if(item.Key.type == ItemType.Miscellaneous)
                tempItems[item.Key] = item.Value;
        PopulateInventoryWindow(tempItems);
        seletedTab = ItemType.Miscellaneous;
    }

    public void Clear(){
        Transform portraitTransform;
        while(itemsContainer.childCount != 0){
            portraitTransform = itemsContainer.GetChild(0);
            Button button = portraitTransform.gameObject.GetComponent<Button>();
            Destroy(button);
            Enqueue(portraitTransform.gameObject);
        }
    }

    public void EquipHead()
    {
        Player.Instance.EquipHead(
            changeClothesWindowController.heads[changeClothesWindowController.currentHead]
        );
        Hide();
    }

    public void EquipBody()
    {
        Player.Instance.EquipBody(
            changeClothesWindowController.bodies[changeClothesWindowController.currentBody]
        );
        Hide();
    }

    public void EquipLegs()
    {
        Player.Instance.EquipLegs(
            changeClothesWindowController.legs[changeClothesWindowController.currentLegs]
        );
        Hide();
    }

    public void ToogleInventory()
    {
        if(isOpen)
            Hide();
        else
            Show();
    }

    public void Show()
    {
        TogglePos(panel, ShowKey);
        SelectClothes();
        isOpen = true;
    }

    public void Hide()
    {
        TogglePos(panel, HideKey);
        CloseClothesWindow();
        Clear();
        isOpen = false;
    }

    public void ShowClothesWindow()
    {
        changeClothesWindowController.Show();
        changeClothesWindowController.PopulateChangeClothes();
        mainWindow.SetActive(false);
    }

    public void CloseClothesWindow()
    {
        changeClothesWindowController.Hide();
        mainWindow.SetActive(true);
    }
}
