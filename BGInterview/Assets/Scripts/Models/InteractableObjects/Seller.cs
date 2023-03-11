using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : InteractableObject
{
    [SerializeField] private ShopUIController shopUIController;
    [SerializeField] private List<Clothes> clothes;

    public override void Interaction()
    {
        shopUIController.SetItemsToBuy(clothes);
        shopUIController.ShowShop();
    }
}
