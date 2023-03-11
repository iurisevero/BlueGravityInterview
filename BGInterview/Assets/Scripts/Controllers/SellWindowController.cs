using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellWindowController : MonoBehaviour
{
    const string HideKey = "Hide";
    const string ShowKey = "Show";
    const string SellItemPoolKey = "SellWindowController.SellItem";
    [SerializeField] private Panel panel;
    [SerializeField] private Image returnSupport;
    [SerializeField] private TextMeshProUGUI totalPriceText;
    [SerializeField] private RectTransform itemsContainer;
    [SerializeField] private GameObject sellItemPortraitPrefab;

    private void Start()
    {
        totalPriceText.text = "0";
        GameObjectPoolController.AddEntry(SellItemPoolKey, sellItemPortraitPrefab, 3, 10);
    }

    private void TogglePos(string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    private IEnumerator maskReturnSupportCoroutine(bool mask)
    {
        yield return new WaitForSeconds(0.1f);
        returnSupport.maskable = mask;
    }

    private SellItemPortraitController Dequeue(){
        Poolable p = GameObjectPoolController.Dequeue(SellItemPoolKey);
        SellItemPortraitController portraitController = p.GetComponent<SellItemPortraitController>();
        portraitController.transform.localScale = Vector3.one;
        portraitController.gameObject.SetActive(true);
        return portraitController;
    }

    private void Enqueue(GameObject portraitObject){
        Poolable p = portraitObject.GetComponent<Poolable>();
        GameObjectPoolController.Enqueue(p);
    }

    public List<SellItemPortraitController> PopulateSellWindow(
        Dictionary<Item, int> items, Dictionary<Item, int> selectedItems
    )
    {
        Clear();
        List<SellItemPortraitController> portraits = new List<SellItemPortraitController>();
        foreach(var item in items){
            SellItemPortraitController portraitController = Dequeue();
            portraitController.SetItem(
                item.Key, item.Value, 
                selectedItems.ContainsKey(item.Key)? selectedItems[item.Key] : 0
            );
            portraitController.transform.SetParent(itemsContainer, false);
            portraits.Add(portraitController);
        }
        return portraits;
    }

    public void Clear(){
        Transform portraitTransform;
        while(itemsContainer.childCount != 0){
            portraitTransform = itemsContainer.GetChild(0);
            Enqueue(portraitTransform.gameObject);
        }
    }

    public void SetTotalPriceText(float totalPrice)
    {
        totalPriceText.text = totalPrice.ToString();
    }

    public void Show()
    {
        TogglePos(ShowKey);
        StartCoroutine(maskReturnSupportCoroutine(false));
    }

    public void Hide()
    {
        TogglePos(HideKey);
        StartCoroutine(maskReturnSupportCoroutine(true));
    }
}
