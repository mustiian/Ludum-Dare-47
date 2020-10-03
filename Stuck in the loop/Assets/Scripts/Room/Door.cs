
using System;
using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private BoxTrigger2D trigger;

        private void Awake()
        {
            trigger.OnEnter += OnMyTriggerEnter;
            trigger.OnExit += OnMyTriggerExit;
        }

        private void OnMyTriggerEnter(Collider2D other)
        {
            Debug.Log($"Someone entered a door: {name}");
        }
        
        private void OnMyTriggerExit(Collider2D triggered)
        {
            Debug.Log($"Someone exited a door: {name}");
        }
    }
}

