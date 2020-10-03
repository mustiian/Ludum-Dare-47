using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerInteraction : MonoBehaviour
{
    public bool Interact;

    private BoxCollider2D InteractionTrigger;

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

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Interact = false;
    }
}
