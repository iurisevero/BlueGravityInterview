using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Item item;
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.root.tag == "Player"){
            Debug.Log("Triggered by player");
            Player.GetInstance.SetInteractableObject(this);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.transform.root.tag == "Player"){
            Debug.Log("Player exits");
            Player.GetInstance.SetInteractableObject(null);
        }
    }

    public virtual void Interaction(){
        Debug.Log("Interaction realized!");
    }
}
