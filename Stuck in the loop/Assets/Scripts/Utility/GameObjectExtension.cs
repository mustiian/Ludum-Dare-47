using UnityEngine;

namespace Utility
{
    public static class GameObjectExtension
    {
        public static bool HasLayerMask(this GameObject gameObject, LayerMask mask)
        {
            return (mask.value & 1 << gameObject.layer) > 0;
        }
    }
}