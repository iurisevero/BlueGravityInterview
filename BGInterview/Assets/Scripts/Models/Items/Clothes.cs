using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "ScriptableObjects/Clothes", order = 1)]
public class Clothes : Item
{
    public AnimatorOverrideController animatorController;
    public Sprite defaultSprite;

    public override void Use()
    {
        Debug.Log(itemName + " used");
    }
}
