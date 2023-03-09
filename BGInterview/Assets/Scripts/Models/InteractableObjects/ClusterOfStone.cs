using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO: Create a messyClusterOfStones sprite and change the Destroy call 
// for a "exploredClusterOfStones" function (if there is time)

public class ClusterOfStone : InteractableObject
{
    [SerializeField] private int minCoinsAmount;
    [SerializeField] private int maxCoinsAmount;

    public override void Interaction()
    {
        int coinsAmount = Random.Range(minCoinsAmount, maxCoinsAmount);
        Debug.Log(coinsAmount + " coins were found");
        Player.Instance.AddCoins(coinsAmount);
        Destroy(this);
    }
}
