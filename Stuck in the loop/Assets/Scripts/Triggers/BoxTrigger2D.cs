
using UnityEngine;
using Utility;

namespace Game
{
    public class BoxTrigger2D : Trigger2D
    {        
        [SerializeField] private LayerMask collisionLayer;
        [SerializeField] private string collisionTag;
        [SerializeField] private bool debug;

        // Event listening
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.isTrigger) return;
            if (!other.gameObject.HasLayerMask(collisionLayer)) return;
            if (!string.IsNullOrEmpty(collisionTag) && !other.gameObject.CompareTag(collisionTag)) return;

            colliders.Add(other);

            if (debug) Debug.Log($"{other.name} has entered a trigger: {name}");

            CastEnterEvent(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.isTrigger) return;
            if (colliders.Contains(other))
            {
                colliders.Remove(other);
                
                if (debug) Debug.Log($"Something has exited a trigger: {name}");
                
                CastExitEvent(other);
            }
        }
    }
}

