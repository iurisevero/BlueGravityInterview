using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gem", menuName = "ScriptableObjects/Gem", order = 1)]
public class Gem : Item
{
    public override void Use()
    {
        Debug.Log("This " + itemName + " is beautiful!");
    }
}
