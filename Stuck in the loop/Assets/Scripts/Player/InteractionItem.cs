using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    public GameObject InteractedItem;

    private bool carryItem;

    public void CarryItem(GameObject gameObject)
    {
        InteractedItem = gameObject;
    }

    public void DropItem()
    {
        InteractedItem = null;
    }

    public bool HasInteractedItem()
    {
        return (InteractedItem != null);
    }
}
