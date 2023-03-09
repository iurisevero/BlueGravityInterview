using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    #region Singleton Pattern
    private static readonly Player Instance;
	private Player() {}
	public static Player GetInstance => Instance;
	#endregion

    public Dictionary<Item, int> Inventory;
    public int coins = 0;
    public InteractableObject interactableObject { get; private set; }

    private void Start()
    {
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
}
