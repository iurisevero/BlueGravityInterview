using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO: Create a messyClusterOfStones sprite and change the Destroy call 
// for a "exploredClusterOfStones" function (if there is time)

public class ClusterOfStone : InteractableObject
{
    [SerializeField] private int minCoinsAmount;
    [SerializeField] private int maxCoinsAmount;
    [SerializeField] private Sprite floatSprite;

    public override void Interaction()
    {
        int coinsAmount = Random.Range(minCoinsAmount, maxCoinsAmount);
        Debug.Log(coinsAmount + " coins were found");
        Player.Instance.AddCoins(coinsAmount);
        FloatingSpriteController.Instance.FloatSprite(this.transform, floatSprite);
        StartCoroutine(WaitToDestroy());
    }

    private IEnumerator WaitToDestroy()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
