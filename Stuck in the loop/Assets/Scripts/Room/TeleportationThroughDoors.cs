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
        [SerializeField] private int mirrorLayer;


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
            var mirror = new Mirror(actor, fromDoor, toDoor, mirrorLayer);
            mirrors.Add(mirror);
        }

        private void OnEndInDoorUsing((GameObject self, bool isWalkedThrough) user)
        {
            var mirror = mirrors.FirstOrDefault((instance) => instance.original == user.self);
            if (mirror == null) return;

            mirrors.Remove(mirror);
            mirror.Complete(user.isWalkedThrough);
        }

        private class Mirror
        {
            public readonly GameObject original;
            private readonly GameObject clone;
            private readonly Door fromDoor;
            private readonly Door toDoor;
            

            public Mirror(GameObject original, Door fromDoor, Door toDoor, int mirrorLayer)
            {
                this.original = original;
                this.fromDoor = fromDoor;
                this.toDoor = toDoor;
                this.clone = Instantiate(original);
                this.clone.name = $"{original.name} - {clone.GetInstanceID()}";
                this.clone.layer = mirrorLayer;
                
                // foreach (var collider in this.clone.GetComponentsInChildren<Collider2D>())
                // {
                //     collider.enabled = false;
                // }

                Synchronize();
            }

            public void Synchronize()
            {
                var originalInDoorPosition = fromDoor.transform.InverseTransformPoint(this.original.transform.position);
                var originalInDoorForward = fromDoor.transform.InverseTransformVector(this.original.transform.forward);

                this.clone.transform.position = toDoor.transform.TransformPoint(-originalInDoorPosition);
                // this.clone.transform.forward = toDoor.transform.TransformVector(-originalInDoorForward);
            }

            public void Complete(bool isWalkedThrough)
            {
                if (clone == null) return;

                if (isWalkedThrough)
                {
                    original.transform.Copy(clone.transform);

                    if(original.TryGetComponent(out Rigidbody2D body))
                    {
                        body.velocity = Vector3.zero;
                        body.angularVelocity = 0f;
                    }
                }

                Destroy(clone);
            }
        }
    }
}