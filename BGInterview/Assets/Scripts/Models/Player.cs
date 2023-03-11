using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Singleton<Player>
{
    private int maxItems = 999;
    private int maxCoins = 999999;
    [SerializeField] WorldUIController worldUIController;

    public Rigidbody2D _rigidbody2D { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    public HashSet<Head> heads = new HashSet<Head>();
    public HashSet<Body> bodies = new HashSet<Body>();
    public HashSet<Legs> legs = new HashSet<Legs>();
    public float coins = 0;
    public InteractableObject interactableObject { get; private set; }
    public Clothes equippedClothes, initialClothes;
    public SpriteRenderer headSprite;
    public SpriteRenderer bodySprite;
    public SpriteRenderer lArmSprite;
    public SpriteRenderer rArmSprite;
    public SpriteRenderer lLegSprite;
    public SpriteRenderer rLegSprite;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        interactableObject = null;

        EquipHead(initialClothes.head);
        EquipBody(initialClothes.body);
        EquipLegs(initialClothes.legs);
        heads.Add(equippedClothes.head);
        bodies.Add(equippedClothes.body);
        legs.Add(equippedClothes.legs);
    }

    public void EquipHead(Head head)
    {
        equippedClothes.head.headBack = head.headBack;
        equippedClothes.head.headFront = head.headFront;
        equippedClothes.head.headLeft = head.headLeft;
        equippedClothes.head.headRight = head.headRight;
        UpdateVisual();
    }

    public void EquipBody(Body body)
    {
        equippedClothes.body.bodyBack = body.bodyBack;
        equippedClothes.body.bodyFront = body.bodyFront;
        equippedClothes.body.bodyLeft = body.bodyLeft;
        equippedClothes.body.bodyRight = body.bodyRight;
        equippedClothes.body.lArm = body.lArm;
        equippedClothes.body.rArm = body.rArm;
        UpdateVisual();
    }

    public void EquipLegs(Legs legs)
    {
        equippedClothes.legs.lLeg = legs.lLeg;
        equippedClothes.legs.rLeg = legs.rLeg;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        headSprite.sprite = equippedClothes.head.headFront;
        bodySprite.sprite = equippedClothes.body.bodyFront;
        lArmSprite.sprite = equippedClothes.body.lArm;
        rArmSprite.sprite = equippedClothes.body.rArm;
        lLegSprite.sprite = equippedClothes.legs.lLeg;
        rLegSprite.sprite = equippedClothes.legs.rLeg;
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
        worldUIController.UpdateCoins();
    }

    public bool RemoveCoins(float coinsAmount)
    {
        if(coinsAmount > coins)
            return false;
        
        coins -= coinsAmount;
        worldUIController.UpdateCoins();
        return true;
    }
}
