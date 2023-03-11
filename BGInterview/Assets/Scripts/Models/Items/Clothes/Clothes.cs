using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "ScriptableObjects/Clothes", order = 1)]
public class Clothes : Item
{
    public Head head;
    public Body body;
    public Legs legs;
    public override void Use()
    {
        Debug.Log(itemName + " used");
    }
}
