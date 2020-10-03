using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Trigger2D : MonoBehaviour
    {
        public event Action<Collider2D> OnEnter;
        public event Action<Collider2D> OnExit;

        protected readonly HashSet<Collider2D> colliders = new HashSet<Collider2D>();

        protected void CastEnterEvent(Collider2D collider)
        {
            OnEnter?.Invoke(collider);
        }

        protected void CastExitEvent(Collider2D collider)
        {
            OnExit?.Invoke(collider);
        }

        public IEnumerable<Collider2D> GetCollisions() => colliders;
    }
}