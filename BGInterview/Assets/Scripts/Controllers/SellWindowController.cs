using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellWindowController : MonoBehaviour
{
    const string HideKey = "Hide";
    const string ShowKey = "Show";
    [SerializeField] private Panel panel;
    [SerializeField] private Image returnSupport;
    [SerializeField] private TextMeshProUGUI totalPriceText;
    [SerializeField] private RectTransform itemsContainer;

    private void TogglePos(string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    private IEnumerator maskReturnSupportCoroutine(bool mask)
    {
        yield return new WaitForSeconds(0.2f);
        returnSupport.maskable = mask;
    }

    public void SetTotalPriceText(int totalPrice)
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
