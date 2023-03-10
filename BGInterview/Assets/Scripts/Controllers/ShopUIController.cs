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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ExitShop();
    }

    private void TogglePos(Panel panel, string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    public void ShowShop()
    {
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
}
