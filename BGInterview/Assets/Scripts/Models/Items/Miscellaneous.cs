using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Miscellaneous", menuName = "ScriptableObjects/Miscellaneous", order = 1)]
public class Miscellaneous : Item
{
    public override void Use()
    {
        Debug.Log("So... What are you for " + itemName + "?");
    }
}
