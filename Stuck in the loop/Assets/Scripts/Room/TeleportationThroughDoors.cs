using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Game
{
    public class TeleportationThroughDoors : MonoBehaviour
    {
        [SerializeField] private Door fromDoor;
        [SerializeField] private Door toDoor;
        
        
        private readonly List<Mirror> mirrors = new List<Mirror>();


        private void Awake()
        {
            fromDoor.OnBeginUsing += OnBeginInDoorUsing;
            fromDoor.OnEndUsing += OnEndInDoorUsing;
        }

        private void Update()
        {
            foreach (var mirror in mirrors)
            {
                mirror.Synchronize();
            }
        }

        private void OnBeginInDoorUsing(GameObject actor)
        {
            var mirror = new Mirror(actor, fromDoor, toDoor);
            mirrors.Add(mirror);
        }

        private void OnEndInDoorUsing((GameObject self, bool isWalkedThrough) user)
        {
            var mirror = mirrors.FirstOrDefault((instance) => instance.original == user.self);
            if (mirror == null) return;

            mirrors.Remove(mirror);
            
            if (user.isWalkedThrough)
            {
                mirror.original.transform.Copy(mirror.clone.transform);
            }

            Destroy(mirror.clone);
        }

        private class Mirror
        {
            public readonly GameObject original;
            public readonly GameObject clone;
            private readonly Door fromDoor;
            private readonly Door toDoor;
            

            public Mirror(GameObject original, Door fromDoor, Door toDoor)
            {
                this.original = original;
                this.clone = Instantiate(original);
                this.fromDoor = fromDoor;
                this.toDoor = toDoor;
                
                Synchronize();
            }

            public void Synchronize()
            {
                var originalInDoorPosition = fromDoor.transform.InverseTransformPoint(this.original.transform.position);
                var originalInDoorForward = fromDoor.transform.InverseTransformVector(this.original.transform.forward);

                this.clone.transform.position = toDoor.transform.TransformPoint(originalInDoorPosition);
                this.clone.transform.forward = toDoor.transform.TransformVector(originalInDoorForward);
            }
        }
    }
}