using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Singleton<Player>
{
    private int maxItems = 999;
    private int maxCoins = 999999;

    public Rigidbody2D _rigidbody2D { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    public float coins = 0;
    public InteractableObject interactableObject { get; private set; }
    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer lArm;
    public SpriteRenderer rArm;
    public SpriteRenderer lLeg;
    public SpriteRenderer rLeg;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        interactableObject = null;
    }

    public void SetInteractableObject(InteractableObject obj)
    {
        Debug.Log("InteractableObject = " + obj);
        interactableObject = obj;
    }

    public void Interact()
    {
        if(interactableObject != null)
            interactableObject.Interaction();
        else
            Debug.Log("Theres nothing here...");
    }

    public void AddItemToInventory(Item item, int quantity = 1)
    {
        if(inventory.ContainsKey(item)){
            if(inventory[item] == maxItems){    
                Debug.Log("You can have more " + item.itemName);
                return;
            }
            inventory[item] = Mathf.Min(inventory[item] + quantity, maxItems);
        } else{
            inventory[item] = Mathf.Min(quantity, maxItems);
        }
    }

    public void RemoveItemToInventory(Item item, int quantity = 1)
    {
        if(!inventory.ContainsKey(item)){
            Debug.Log(item.itemName + " not found...");
            return;
        }

        inventory[item] = Mathf.Max(inventory[item] - quantity, 0);

        if(inventory[item] <= 0)
            inventory.Remove(item);
    }

    public void AddCoins(float coinsAmount)
    {
        coins = Mathf.Min(coins + coinsAmount, maxCoins);
    }

    public bool RemoveCoins(float coinsAmount)
    {
        if(coinsAmount > coins)
            return false;
        
        coins -= coinsAmount;
        return true;
    }
}
