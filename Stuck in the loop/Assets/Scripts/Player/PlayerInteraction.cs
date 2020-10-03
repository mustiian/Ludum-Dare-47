using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerInteraction : MonoBehaviour
{
    public bool Interact;

    private GameObject interactObject;

    [SerializeField] private BoxTrigger2D InteractionTrigger;

    // Start is called before the first frame update
    void Start()
    {
        InteractionTrigger.OnEnter += OnMyTriggerEnter;
        InteractionTrigger.OnExit += OnMyTriggerExit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Interact)
        {
            CheckLeverActivation(interactObject.GetComponent<LeverManager>());
        }
    }

    private void OnMyTriggerExit(Collider2D triggered)
    {
        if (interactObject == triggered.gameObject)
        {
            Interact = false;
            interactObject = null;
        }
    }

    private void OnMyTriggerEnter(Collider2D other)
    {
        if (interactObject == null)
        {
            Interact = true;
            interactObject = other.gameObject;
        }
    }

    private void CheckLeverActivation(LeverManager lever)
    {
        if (lever != null)
            lever.ActivateLight();
    }
}
