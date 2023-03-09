using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : InteractableObject
{
    [SerializeField] private bool hasFruit;
    [SerializeField] private int minFruitsDrop = 2;
    [SerializeField] private int maxFruitsDrop = 6;
    [SerializeField] private float timeToRespawnTree = 15f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite noFruitBush;
    [SerializeField] private Sprite fruitBush;
    [SerializeField] private Fruit fruit;

    public override void Interaction()
    {
        if(hasFruit){
            int fruitQuantity = Random.Range(minFruitsDrop, maxFruitsDrop + 1);
            Debug.Log(fruitQuantity + " " + fruit.itemName + " were found");
            Player.Instance.AddItemToInventory(fruit, fruitQuantity);
            hasFruit = false;
            spriteRenderer.sprite = noFruitBush;
            StartCoroutine(Respawn());
        } else{
            Debug.Log("There is no fruits here...");
        }
    }

    private void Start()
    {
        hasFruit = Random.Range(1, 100) < 50;
        spriteRenderer.sprite = (hasFruit? fruitBush : noFruitBush);
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeToRespawnTree);
        hasFruit = true;
        spriteRenderer.sprite = fruitBush;
    }
}
