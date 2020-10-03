
using UnityEngine;

namespace Game
{
    public class BoxTrigger2D : Trigger2D
    {        
        [SerializeField] private LayerMask collisionLayer;
        [SerializeField] private string collisionTag;


        // Event listening
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.IsTouchingLayers(collisionLayer)) return;
            if (!string.IsNullOrEmpty(collisionTag) && !other.gameObject.CompareTag(collisionTag)) return;

            colliders.Add(other);

            Debug.Log($"Something has entered a trigger: {name}");

            CastEnterEvent(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (colliders.Contains(other))
            {
                colliders.Remove(other);
            }
            
            Debug.Log($"Something has exited a trigger: {name}");
            
            CastExitEvent(other);
        }
    }
}

