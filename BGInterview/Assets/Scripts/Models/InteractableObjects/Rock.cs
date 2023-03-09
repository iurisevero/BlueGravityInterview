using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO: Create a brokenRock sprite and change the Destroy call 
// for a "minedRock" function (if there is time)

public class Rock : InteractableObject
{
    [SerializeField] private Gem[] gems;

    public override void Interaction()
    {
        Gem gem = GetRandomGem();
        Debug.Log("A " + gem.itemName + " were found");
        Player.Instance.AddItemToInventory(gem);
        Destroy(this.gameObject);
    }

    private Gem GetRandomGem()
    {
        return gems[Random.Range(0, gems.Length)];
    }
}
