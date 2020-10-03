using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Game.BoxTrigger2D trigger;

    private void Awake()
    {
        trigger.OnEnter += OnMyTriggerEnter;
        trigger.OnExit += OnMyTriggerExit;
    }

    private void OnMyTriggerEnter(Collider2D other)
    {
        Debug.Log($"Box is on platform: {name}");
    }

    private void OnMyTriggerExit(Collider2D triggered)
    {
        Debug.Log($"Box is out platform: {name}");
    }
}

