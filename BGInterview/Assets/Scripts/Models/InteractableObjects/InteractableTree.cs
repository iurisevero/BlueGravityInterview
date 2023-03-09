using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Couldn't use the name "Tree" cause Unity already uses it
public class InteractableTree : InteractableObject
{
    [SerializeField] private bool isAlive = true;
    [SerializeField] private int minLogsQuantity = 3;
    [SerializeField] private int maxLogsQuantity = 8;
    [SerializeField] private int chanceToDropFruit = 10;
    [SerializeField] private float timeToRespawnTree = 60f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite deadTree;
    [SerializeField] private Sprite tree;
    [SerializeField] private Fruit fruit;
    [SerializeField] private Miscellaneous logs;
    private int logsQuantity;

    public override void Interaction()
    {
        if(isAlive){
            logsQuantity--;
            Debug.Log("A log was taken. " + logsQuantity + " logs left.");
            Player.Instance.AddItemToInventory(logs);

            if(Random.Range(1, 100) < chanceToDropFruit){
                Debug.Log("A fruit was taken.");
                Player.Instance.AddItemToInventory(fruit);
            }

            if(logsQuantity == 0){
                Die();
            }
        } else{
            Debug.Log("The tree is dead...");
        }
    }

    private void Start()
    {
        logsQuantity = Random.Range(minLogsQuantity, maxLogsQuantity + 1);
    }

    private void Die()
    {
        isAlive = false;
        spriteRenderer.sprite = deadTree;
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeToRespawnTree);
        isAlive = true;
        spriteRenderer.sprite = tree;
        logsQuantity = Random.Range(minLogsQuantity, maxLogsQuantity + 1);
    }
}
