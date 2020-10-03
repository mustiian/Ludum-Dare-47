
using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private 

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(triggerTag))
            {
                Debug.Log($"Door {name} triggered!");
            }
        }
    }
}

