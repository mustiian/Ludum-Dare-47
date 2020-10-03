using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerInteraction : MonoBehaviour
{
    public bool Interact;

    private BoxCollider2D InteractionTrigger;

    private GameObject interactObject;

    // Start is called before the first frame update
    void Start()
    {
        InteractionTrigger = GetComponent<BoxCollider2D>();
        InteractionTrigger.isTrigger = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Interact)
        {
            Debug.Log(interactObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (interactObject == null)
        {
            Interact = true;
            interactObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactObject == other.gameObject)
        {
            Interact = false;
            interactObject = null;
        }
    }
}
