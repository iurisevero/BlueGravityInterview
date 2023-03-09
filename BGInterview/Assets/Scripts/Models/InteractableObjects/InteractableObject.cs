using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.root.tag == "Player"){
            Debug.Log("Triggered by player");
            Player.Instance.SetInteractableObject(this);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.transform.root.tag == "Player"){
            Debug.Log("Player exits");
            Player.Instance.SetInteractableObject(null);
        }
    }

    public virtual void Interaction(){
        Debug.Log("Interaction realized!");
    }
}
