using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerBoxInteraction : MonoBehaviour
{
    [SerializeField] private BoxTrigger2D InteractionTrigger;

    private BoxStats interactObject;
    private Rigidbody2D pickedBoxRigidbody;
    private Rigidbody2D playerRigidbody;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        InteractionTrigger.OnEnter += OnMyTriggerEnter;
        InteractionTrigger.OnExit += OnMyTriggerExit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactObject != null)
        {
            if (pickedBoxRigidbody == null)
                PickUpBox(interactObject);
            else
                DropBox();
        }
    }

    private void FixedUpdate()
    {
        if (pickedBoxRigidbody != null)
            pickedBoxRigidbody.position = playerRigidbody.position + offset;
    }

    private void OnMyTriggerExit(Collider2D triggered)
    {
        if (interactObject?.gameObject == triggered.gameObject)
        {
            
            interactObject = null;
        }
    }

    private void OnMyTriggerEnter(Collider2D other)
    {
        if (interactObject == null)
        {
            interactObject = other.gameObject.GetComponent<BoxStats>();
        }
    }

    private void PickUpBox(BoxStats box)
    {
        if (box != null)
        {
            if (box.IsDragable())
            {
                pickedBoxRigidbody = box.GetComponent<Rigidbody2D>();
                offset = pickedBoxRigidbody.position - playerRigidbody.position;
            }
        }
    }

    private void DropBox()
    {
        pickedBoxRigidbody = null;
    }
}
