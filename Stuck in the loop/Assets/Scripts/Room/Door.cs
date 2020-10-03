
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Trigger2D trigger;
        [SerializeField] private Transform entrancePlaceA;
        [SerializeField] private Transform entrancePlaceB;
        [SerializeField] private bool debug;

        private readonly List<Transition> transitions = new List<Transition>();

        public event Action<GameObject> OnBeginUsing;
        public event Action<(GameObject actor, bool isWalkedThrough)> OnEndUsing;

        
        private void Awake()
        {
            trigger.OnEnter += OnMyTriggerEnter;
            trigger.OnExit += OnMyTriggerExit;
        }

        private void OnMyTriggerEnter(Collider2D triggered)
        {
            transitions.Add(new Transition(triggered.gameObject, entrancePlaceA, entrancePlaceB));

            if (debug) Debug.Log($"Object: {triggered.name} has entered a door: {name}");
            
            OnBeginUsing?.Invoke(triggered.gameObject);
        }

        private void OnMyTriggerExit(Collider2D triggered)
        {
            var transition = transitions.FirstOrDefault((item) => item.actor == triggered.gameObject);
            if (transition == null) return;

            transitions.Remove(transition);
            var result = (transition.actor, transition.IsSuccesful());
            
            if (debug) Debug.Log(
                transition.IsSuccesful() 
                    ? $"Object: {triggered.name} has walked through a door: {name}"
                    : $"Object: {triggered.name} has went back, and didn't used a door: {name}"
            );

            OnEndUsing?.Invoke(result);
        }


        private class Transition
        {
            public readonly GameObject actor;
            private readonly Transform enter;
            private readonly Transform exit;

            public Transition(GameObject actor, Transform placeA, Transform placeB)
            {
                var position = actor.transform.position;
                var distanceToA = Vector3.Distance(placeA.position, position);
                var distanceToB = Vector3.Distance(placeB.position, position);
                var isPlaceACloser = distanceToA < distanceToB;
                
                this.actor = actor;
                this.enter = isPlaceACloser ? placeA : placeB;
                this.exit = isPlaceACloser ? placeB : placeA;
            }

            public bool IsSuccesful()
            {
                var position = actor.transform.position;
                var distanceToEnter = Vector3.Distance(enter.position, position);
                var distanceToExit = Vector3.Distance(exit.position, position);

                return distanceToExit < distanceToEnter;
            }
        }
    }
}

