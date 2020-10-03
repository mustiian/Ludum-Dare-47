using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerLeverInteraction : MonoBehaviour
{
    [SerializeField] private BoxTrigger2D InteractionTrigger;

    private LeverManager interactObject;

    // Start is called before the first frame update
    void Start()
    {
        InteractionTrigger.OnEnter += OnMyTriggerEnter;
        InteractionTrigger.OnExit += OnMyTriggerExit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactObject != null)
        {
            if (!interactObject.Activated)
                LeverActivation(interactObject);
            else
                LeverDeactivation(interactObject);
        }
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
            interactObject = other.gameObject.GetComponent<LeverManager>();
        }
    }

    private void LeverActivation(LeverManager lever)
    {
        if (lever != null) {
            lever.ActivateLight();
        }
    }

    private void LeverDeactivation(LeverManager lever)
    {
        if (lever != null) {
            lever.DeactivateLight();
        }
    }
}
