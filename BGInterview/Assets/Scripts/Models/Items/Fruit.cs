using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "ScriptableObjects/Fruit", order = 1)]
public class Fruit : Item
{
    public override void Use()
    {
        Debug.Log("This " + itemName + " was delicious!");
    }
}